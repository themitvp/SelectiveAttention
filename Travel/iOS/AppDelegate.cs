﻿using Foundation;
using System.Linq;
using UIKit;
using System;
using System.IO;
using SQLite;
using PersonalDataApi;
using Xuni.iOS.Core;

namespace Travel.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		public static AppDelegate Current { get; private set; }
		public MyEventManager MyEventManager { get; set; }
		public MyStatManager MyStatManager { get; set; }
		SQLiteConnection conn;

		private TabbedHomeViewController tabController;

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Current = this;

			// create a new window instance based on the screen size
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			// make the window visible
			Window.MakeKeyAndVisible();

			// Make the font in the status bar white
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

			// Check for User ID
			if (String.IsNullOrEmpty(GlobalVariables.NSUserId)) {
				// First time user opens the app, as User Id is not set
				var UserId = Guid.NewGuid();
				Console.WriteLine(UserId);
				// Save User Id 
				GlobalVariables.NSUserId = UserId.ToString();

				var authenticationRequest = new AuthenticationRequest {
					UserId = UserId
				};

				var authResult = PersonalDataApiRepository.Get<AuthenticationRequest,AuthenticationResponse> (authenticationRequest);

				// Open Moves app to allow us to collect data
				var request = new NSUrl(authResult.Url);
				try {
					UIApplication.SharedApplication.OpenUrl(request);
				} catch (Exception ex) {
					Console.WriteLine ("Cannot open url: {0}, Error: {1}", request.AbsoluteString,  ex.Message);
					var alertView = new UIAlertView("Error", ex.Message, null, "OK", null);

					alertView.Show();
				}
			}

			// Create the database file
			var sqliteFilename = "MyEventsDB.db3";
			// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
			// (they don't want non-user-generated data in Documents)
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);
			conn = new SQLiteConnection(path);
			MyEventManager = new MyEventManager(conn);
			MyStatManager = new MyStatManager(conn);

			tabController = new TabbedHomeViewController();
			Window.RootViewController = tabController;
			Window.MakeKeyAndVisible();

			// Ask for permission to show local notifications
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes (
					UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
				);

				application.RegisterUserNotificationSettings (notificationSettings);
			}

			// check for a notification
			if (launchOptions != null)
			{
				// check for a local notification
				if (launchOptions.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
				{
					var localNotification = launchOptions[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
					if (localNotification != null)
					{
						UIAlertController okayAlertController = UIAlertController.Create (localNotification.AlertAction, localNotification.AlertBody, UIAlertControllerStyle.Alert);
						okayAlertController.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Default, alert => {
							tabController.OpenedFromNotification();
						}));

						tabController.PresentViewController (okayAlertController, true, null);

						// reset our badge
						UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
					}
				}
			}

			XuniLicenseManager.Key = License.Key;


			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				var pushSettings = UIUserNotificationSettings.GetSettingsForTypes (
					UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
					new NSSet ());

				UIApplication.SharedApplication.RegisterUserNotificationSettings (pushSettings);
				UIApplication.SharedApplication.RegisterForRemoteNotifications ();
			} else {
				UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (notificationTypes);
			}



			return true;
		}

		public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
		{
			// show an alert
			UIAlertController okayAlertController = UIAlertController.Create (notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
			okayAlertController.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Default, alert => {
				tabController.OpenedFromNotification();
			}));
			tabController.PresentViewController (okayAlertController, true, null);

			// reset our badge
			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}


	//	public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
//		{
			// Get current device token
	//		var DeviceToken = deviceToken.Description;
		//	if (!string.IsNullOrWhiteSpace(DeviceToken)) {
			//	DeviceToken = DeviceToken.Trim('<').Trim('>');
		//	}

			// Get previous device token
		//	var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

			// Has the token changed?
			//if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(DeviceToken))
		//	{
				//TODO: Put your own logic here to notify your server that the device token has changed/been created!
		//	}

			// Save new device token 
			//NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, "PushDeviceToken");
		//}

		public override void FailedToRegisterForRemoteNotifications (UIApplication application , NSError error)
		{
			//new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
		}
	}
}


