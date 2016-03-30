using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.Collections.Generic;
using CoreAnimation;

namespace Travel.iOS
{
	public class AddEventView : UIView
	{
		
		// Subview properties
		public UIDatePicker datePicker;
		private UITextField dateTextField;
		private UIToolbar myToolbar;
		private UIBarButtonItem btnCancel, btnDone;
		private UIBarButtonItem[] btnItems;
		private UIView pDateView;
		private NSDateFormatter formatDate;
		private UIPickerView typePicker;
		private PickerModel type_model;
		private UIBarButtonItem btnFlexibleSpace, btnFlexibleSpaceDate;

		public UITextField typeOfTransport, direction;
		public UITableView searchResultTable;
		public MyEvent.TravelType selectedTypeOfTransport;
		public AddEventView (CGRect frame, UIViewController parent) : base (frame)
		{
			this.BackgroundColor = UIColor.White;

			var offset = parent.NavigationController.NavigationBar.Frame.Bottom;

			// Initialize & Setup
			dateTextField = new UITextField();
			dateTextField.Placeholder = "Tap here to choose date.. ";
			dateTextField.Font = UIFont.FromName("HelveticaNeue-Light", 17f);

			var bottomBorderDate = new CALayer ();
			bottomBorderDate.BackgroundColor = GlobalVariables.TravelLightGray.CGColor;
			dateTextField.Layer.AddSublayer (bottomBorderDate);

			myToolbar = new UIToolbar(CGRect.Empty);
			myToolbar.BarStyle = UIBarStyle.Black;
			myToolbar.Translucent = true;
			myToolbar.UserInteractionEnabled = true;
			myToolbar.TintColor = UIColor.White;
			myToolbar.SizeToFit();

			formatDate = new NSDateFormatter();
			formatDate.DateFormat = "dd MMM YYYY HH:mm";

			datePicker = new UIDatePicker();
			datePicker.Mode = UIDatePickerMode.DateAndTime;
			datePicker.TimeZone = NSTimeZone.SystemTimeZone;
			datePicker.UserInteractionEnabled = true;
			datePicker.BackgroundColor = UIColor.White;
			datePicker.MinimumDate = new NSDate();


			btnCancel = new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Done, (sender, e) => {
				dateTextField.ResignFirstResponder();
			});
			btnDone = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (sender, e) => {
				dateTextField.Text = formatDate.EditingStringFor(datePicker.Date);
				dateTextField.ResignFirstResponder();
			});

			btnFlexibleSpaceDate = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);

			btnItems = new UIBarButtonItem[] { btnCancel, btnFlexibleSpaceDate, btnDone }; 
			myToolbar.SetItems(btnItems, true);

			pDateView = new UIView();
			pDateView.AddSubview(myToolbar);
			pDateView.AddSubview(datePicker);

			dateTextField.EditingDidBegin += delegate {
				dateTextField.InputView = pDateView;
			};


			// Picker
			typeOfTransport = new UITextField();
			typeOfTransport.Placeholder = "Tap here to select type of transport...";
			typeOfTransport.Font = UIFont.FromName ("HelveticaNeue-Light", 17f);

			var bottomBordertypeOfTransport = new CALayer ();
			bottomBordertypeOfTransport.BackgroundColor = GlobalVariables.TravelLightGray.CGColor;
			typeOfTransport.Layer.AddSublayer (bottomBordertypeOfTransport);


			List<object> typeOptions = new List<object>();

			typeOptions.Add(MyEvent.TravelType.PublicTransport);
			typeOptions.Add(MyEvent.TravelType.Car);
			typeOptions.Add(MyEvent.TravelType.Bicycling);
			typeOptions.Add(MyEvent.TravelType.Running);
			typeOptions.Add(MyEvent.TravelType.Walking);

			type_model = new PickerModel(typeOptions);

			typePicker = new UIPickerView ();
			typePicker.Model = type_model;
			typePicker.BackgroundColor = UIColor.White;
			typePicker.ShowSelectionIndicator = true;

			UIToolbar typePickerToolbar = new UIToolbar ();
			typePickerToolbar.BarStyle = UIBarStyle.Black;
			typePickerToolbar.Translucent = true;
			typePickerToolbar.UserInteractionEnabled = true;
			typePickerToolbar.TintColor = UIColor.White;
			typePickerToolbar.SizeToFit();

			UIBarButtonItem typeCancelButton = new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Done, (s,e) => {
				typeOfTransport.ResignFirstResponder();
			});

			UIBarButtonItem typeDoneButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (s,e) => {
				selectedTypeOfTransport = (MyEvent.TravelType)type_model.values[(int)typePicker.SelectedRowInComponent (0)];
				typeOfTransport.Text = selectedTypeOfTransport.ToString();
				typeOfTransport.ResignFirstResponder();
			});

			btnFlexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);
			typePickerToolbar.SetItems (new UIBarButtonItem[]{typeCancelButton, btnFlexibleSpace, typeDoneButton},true);

			typeOfTransport.EditingDidBegin += delegate {
				typeOfTransport.InputView = typePicker;
				typeOfTransport.InputAccessoryView = typePickerToolbar;
			};

			direction = new UITextField ();
			direction.Placeholder = "Search for a destination below:";
			direction.Font = UIFont.FromName ("HelveticaNeue-Light", 17f);
			direction.UserInteractionEnabled = false;

			var bottomBorder = new CALayer ();
			bottomBorder.BackgroundColor = GlobalVariables.TravelLightGray.CGColor;
			direction.Layer.AddSublayer (bottomBorder);

			// Search for destination
			searchResultTable = new UITableView();
			searchResultTable.ScrollsToTop = false;


			// Set frame
			typeOfTransport.Frame = new CGRect(10, offset, frame.Width - 20, 50);
			dateTextField.Frame = new CGRect(10, typeOfTransport.Frame.Bottom + 5, frame.Width - 20, 50);

			direction.Frame = new CGRect(10, dateTextField.Frame.Bottom + 5, frame.Width - 20, 50);
			searchResultTable.Frame = new CGRect(0, direction.Frame.Bottom, frame.Width, frame.Height - direction.Frame.Bottom);

			datePicker.Frame = new CGRect(0, 44, frame.Width, 216);


			bottomBordertypeOfTransport.Frame = new CGRect (0, typeOfTransport.Frame.Height - 1, typeOfTransport.Frame.Width, 1);
			bottomBorder.Frame = new CGRect (0, direction.Frame.Height - 1, direction.Frame.Width, 1);
			bottomBorderDate.Frame = new CGRect (0, dateTextField.Frame.Height - 1, dateTextField.Frame.Width, 1);

			pDateView.Frame = new CGRect (0, 0, frame.Width, 260);

			// Add subviews
			this.AddSubviews (new UIView[] {
				typeOfTransport,
				dateTextField,
				direction,
				searchResultTable
			});
		}
	}
}

