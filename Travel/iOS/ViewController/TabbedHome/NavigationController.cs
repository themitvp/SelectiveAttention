using System;
using UIKit;

namespace Travel.iOS
{
	public class NavigationController: UINavigationController
	{
		public NavigationController(UIViewController viewController) : base(viewController)
		{
			// Make navigationbas black and transparent
			//NavigationBar.Translucent = true;
			//NavigationBar.BarStyle = UIBarStyle.Default;
			NavigationBar.BarTintColor = GlobalVariables.TravelTurkish;
			NavigationBar.TintColor = UIColor.White;

			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes() {
				TextColor = UIColor.White,
				TextShadowColor = UIColor.Clear,
				Font = UIFont.FromName("HelveticaNeue-Light", 25f)
			}); 
		}

	}
}

