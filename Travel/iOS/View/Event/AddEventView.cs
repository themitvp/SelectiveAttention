using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Travel.iOS
{
	public class AddEventView : UIView
	{
		// Subview label
		private UILabel destinationLabel;

		// Subview properties
		public UIDatePicker datePicker;
		public UITableView searchResultTable;

		public AddEventView (CGRect frame, UIViewController parent) : base (frame)
		{
			this.BackgroundColor = GlobalVariables.TravelLightGray;

			var offset = parent.NavigationController.NavigationBar.Frame.Bottom;

			// Initialize & Setup
			datePicker = new UIDatePicker ();
			datePicker.Mode = UIDatePickerMode.DateAndTime;
			datePicker.TimeZone = NSTimeZone.SystemTimeZone;

			datePicker.UserInteractionEnabled = true;
			datePicker.BackgroundColor = UIColor.White;

			destinationLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue-Light", 23f),
				TextColor = UIColor.Black,
				BackgroundColor = UIColor.White,
				Text = "Destination"
			};

			searchResultTable = new UITableView();
			searchResultTable.ScrollsToTop = false;

			// Set frame
			datePicker.Frame = new CGRect (0, offset, frame.Width, 260);
			searchResultTable.Frame = new CGRect(0, datePicker.Frame.Bottom + 20, frame.Width, frame.Height - (datePicker.Frame.Bottom + 20));

			// Add subviews
			this.AddSubviews (new UIView[] {
				datePicker,
				//destinationLabel,
				searchResultTable
			});
		}
	}
}

