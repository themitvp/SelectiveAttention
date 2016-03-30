using System;
using UIKit;

namespace Travel.iOS
{
	public class TabbedHomeViewController : UITabBarController
	{
		NavigationController nav1;
		NavigationController nav2;
		UIViewController[] tabs;
		StatsViewController vc1;
		HomeViewController vc2;

		public TabbedHomeViewController()
		{
			// create our home controller based on the device
			vc1 = new StatsViewController();
			vc1.TabBarItem = new UITabBarItem();
			vc1.TabBarItem.Image = UIImage.FromBundle("stats");
			vc1.TabBarItem.Title = "Stats";

			vc2 = new HomeViewController();
			vc2.TabBarItem = new UITabBarItem();
			vc2.TabBarItem.Image = UIImage.FromBundle("events");
			vc2.TabBarItem.Title = "Events";

			// create our nav controller
			nav1 = new NavigationController(vc1);
			nav2 = new NavigationController(vc2);

			TabBar.TintColor = GlobalVariables.TravelTurkish;

			//Add each navigation controller into a view controller array
			tabs = new UIViewController[] {
				nav1,
				nav2
			};

			//Add the array to the tabbar controller's list of view controllers (displayed as a tab each)
			ViewControllers = tabs;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			// Make the font in the status bar white
			//UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
		}

		public void OpenedFromNotification()
		{
			vc2.OpenedFromNotification();
		}
	}
}

