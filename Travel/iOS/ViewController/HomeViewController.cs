using System;
using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;

namespace Travel.iOS
{
	public class HomeViewController : UIViewController
	{
		public HomeView _homeView;
		public ObservableCollection<Event> offerList { get; private set; }

		public HomeViewController ()
		{
			Title = "Home";
		}

		public override void LoadView()
		{
			base.LoadView();

			_homeView = new HomeView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _homeView;
		}
	}
}

