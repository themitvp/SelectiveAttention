using System;
using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;
using Foundation;
using JourneyPlanner;
using JourneyPlanner.Model.Repository;
using PersonalDataApi;

using System.Linq;

namespace Travel.iOS
{
	public class HomeViewController : UIViewController
	{
		public HomeView _homeView;
		public ObservableCollection<MyEvent> eventList { get; set; }

		public HomeViewController ()
		{
			Title = "Events";

			eventList = new ObservableCollection<MyEvent> ();
		}

		public override void LoadView()
		{
			base.LoadView();

			_homeView = new HomeView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _homeView;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender,args) => {
					// button was clicked
					this.NavigationController.PushViewController(new AddEventViewController(this), true);
				})
				, true);

			// Make the font in the status bar white
			//UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			PopulateTable();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//OpenedFromNotification ();

			BeginInvokeOnMainThread (delegate {
				_homeView.listTable.Source = new HomeTableSource(this);
				_homeView.listTable.ReloadData();
			});
		}

		protected void PopulateTable()
		{
			eventList.Clear();
			var eventsDB = AppDelegate.Current.MyEventManager.GetMyEvents().ToList();

			foreach (var i in eventsDB) {
				eventList.Add(i);
			}
		}

		public void SaveMyEvent(MyEvent newMyEvent)
		{
			AppDelegate.Current.MyEventManager.SaveMyEvent(newMyEvent);

			var date1 = DateTime.Now;
			var seconds = (newMyEvent.Arrival - date1).TotalSeconds;

			// create the notification
			var notification = new UILocalNotification();

			// set the fire date (the date time in which it will fire)
			notification.FireDate = NSDate.FromTimeIntervalSinceNow(seconds);

			// configure the alert
			notification.AlertAction = "View My Event";
			notification.AlertBody = newMyEvent.Destination + " " + newMyEvent.Arrival.ToString();

			// modify the badge
			notification.ApplicationIconBadgeNumber = 1;

			// set the sound to be the default sound
			notification.SoundName = UILocalNotification.DefaultSoundName;

			// schedule it
			UIApplication.SharedApplication.ScheduleLocalNotification(notification);
		}

		public void OpenedFromNotification()
		{
			/*var tripRequestModel = new TripRequest {
				OriginId = "008603310",
				DestId = "000050100",
				Date = "30.03.16",
				Time = "13:00"
			};

			var departureBoardRequestModel = new DepartureBoardRequest {
				Id = "000050100",
				Date = "30.03.16",
				Time = "15:00"
			};

			var multiBoardRequestModel = new MultiDepartureBoardRequest {
				Id1 = "000050100",
				Id2 = "751446100",
				Id3 = "000046420",
				Date = "30.03.16",
				Time = "15:00"
			};

			var stopsNearbyRequest = new StopsNearbyRequest {
				CoordX = 12565796,
				CoordY = 55673063,
				MaxRadius = 1000,
				MaxNumber = 30
			};

			var journeyDetailsRequest = new JourneyDetailRequest
			{
				DepartureBoardUrl = "http://xmlopen.rejseplanen.dk/bin/rest.exe/journeyDetail?ref=775158%2F283931%2F38946%2F238941%2F86%3Fdate%3D30.03.16%26format%3Djson%26"
			};

				
			var trip = JourneyPlanerRepository.Get<TripRequest, TripResult> (tripRequestModel);

			var departureBoard = JourneyPlanerRepository.Get<DepartureBoardRequest, DepartureBoardResult> (departureBoardRequestModel);

			var multiDepartureBoard = JourneyPlanerRepository.Get<MultiDepartureBoardRequest, MultiDepartureBoardResult> (multiBoardRequestModel);

			var stopsNearby = JourneyPlanerRepository.Get<StopsNearbyRequest, StopsNearbyResult> (stopsNearbyRequest);

			var journeyDetails = JourneyPlanerRepository.Get<JourneyDetailsResult>(journeyDetailsRequest.DepartureBoardUrl);
			*/
		}
	}
}

