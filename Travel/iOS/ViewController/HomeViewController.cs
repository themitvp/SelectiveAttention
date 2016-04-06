using System;
using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;
using Foundation;
using Travel;
using System.Collections.Generic;

namespace Travel.iOS
{
	public class HomeViewController : UIViewController
	{
		public HomeView _homeView;
		public ObservableCollection<MyEvent> eventList { get; set; }
		static NSString HomeCellId = new NSString ("HomeCellId");

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
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var test = new TestJourneyPlanner ();

			var request = test.DoSomething ();

			var location = HttpClientFramework.HttpResponseRepository.Get<JourneyPlanner.Model.LocationResult> (request [0], request [1]).Result;

			BeginInvokeOnMainThread (delegate {
				_homeView.listTable.RegisterClassForCellReuse(typeof(HomeTableCell), HomeCellId);
				_homeView.listTable.Source = new HomeTableSource(this);
				_homeView.listTable.ReloadData();
			});
		}
	}
}

