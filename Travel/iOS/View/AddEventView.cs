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
			//datePicked = (DateTime)datePicker.Date;

			// Set frame
			datePicker.Frame = new CGRect (0, offset, frame.Width, 260);

			// Add subviews
			this.AddSubviews (new UIView[] {
				datePicker
			});
		}
	}
}

