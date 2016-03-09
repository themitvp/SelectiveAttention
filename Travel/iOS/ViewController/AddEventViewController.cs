using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Travel.iOS
{
	public class AddEventViewController : UIViewController
	{
		public AddEventView _addEventView;

		private HomeViewController parent;

		public AddEventViewController (HomeViewController parent)
		{
			Title = "Add Event";
			this.parent = parent;
		}

		public override void LoadView()
		{
			base.LoadView();

			_addEventView = new AddEventView(new CGRect(0,0,View.Frame.Width, View.Frame.Height), this);
			this.View = _addEventView;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender,args) => {
					// button was clicked
					var date = (DateTime)_addEventView.datePicker.Date;
					date = date.AddHours(1);

					var newEvent = new MyEvent() {
						Arrival = date
					};

					parent.eventList.Add(newEvent);

					Console.WriteLine(date);
					this.NavigationController.PopViewController(true);
				})
				, true);
		}
	}
}

