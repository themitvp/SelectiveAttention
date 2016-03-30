using System;
using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;
using Foundation;
using System.Linq;

namespace Travel.iOS
{
	public class HomeViewController : UIViewController
	{
		public HomeView _homeView;
		public ObservableCollection<MyEvent> eventList { get; set; }
		string HomeCellId = "HomeId";

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

			PopulateTable();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			BeginInvokeOnMainThread (delegate {
				//_homeView.listTable.RegisterClassForCellReuse(typeof(UITableViewCell), HomeCellId);
				_homeView.listTable.Source = new HomeTableSource(this);
				_homeView.listTable.ReloadData();
			});
		}

		protected void PopulateTable()
		{
			eventList.Clear();
			var eventsDB = AppDelegate.Current.MyEventManager.GetTasks().ToList();

			foreach (var i in eventsDB) {
				eventList.Add(i);
			}
		}

		public void SaveMyEvent(MyEvent newMyEvent)
		{
			AppDelegate.Current.MyEventManager.SaveTask(newMyEvent);

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
			Console.WriteLine("Opened from notification");
		}
	}
}

