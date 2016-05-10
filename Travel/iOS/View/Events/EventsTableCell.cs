using System;
using UIKit;
using Foundation;
using CoreGraphics;
using SWTableViewCells;

namespace Travel.iOS
{
	[Register ("EventsCellId")]
	public class EventsTableCell : SWTableViewCell
	{
		private UILabel nameLabel, startTime, endTime;
		private UIImageView icon;
		private UIView card, sideBorder;

		public EventsTableCell(IntPtr p) : base (p)
		{
			BackgroundColor = GlobalVariables.TravelLightGray;

			nameLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue-Thin", 25f),
				AdjustsFontSizeToFitWidth = true
			};

			startTime = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue-Light", 16f)
			};

			endTime = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue-Light", 16f)
			};

			icon = new UIImageView();

			card = new UIView();
			card.BackgroundColor = UIColor.White;

			sideBorder = new UIView();
			sideBorder.BackgroundColor = GlobalVariables.TravelTurkish;

			// Add to Cell view
			ContentView.AddSubviews(new UIView[] {
				card,
				sideBorder,
				nameLabel,
				startTime,
				endTime,
				icon
			});
		}

		public void UpdateCell (MyEvent myEvent)
		{	
			nameLabel.Text = myEvent.Name;
			startTime.Text = "Starts\t" + myEvent.StartTime;
			endTime.Text =   "Ends\t" + myEvent.EndTime;

			switch (myEvent.PlaceType) {
			case PlaceTypes.Home:
				icon.Image = UIImage.FromBundle("home");
				break;
			case PlaceTypes.Work:
				icon.Image = UIImage.FromBundle("work");
				break;
			case PlaceTypes.School:
				icon.Image = UIImage.FromBundle("school");
				break;
			default:
				icon.Image = UIImage.FromBundle("location");
				break;
			}
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			var padding = 20;
			var iconSize = 50;
			var cardPadding = 5;
			var sideBorderWidth = 5;

			card.Frame = new CGRect(0, cardPadding, ContentView.Bounds.Width, ContentView.Bounds.Height - cardPadding);

			icon.Frame = new CGRect(ContentView.Bounds.Width - iconSize - padding, card.Frame.Y + (card.Frame.Height-iconSize)/2, iconSize, iconSize);

			sideBorder.Frame = new CGRect(0, card.Frame.Y, sideBorderWidth, card.Frame.Height);

			nameLabel.SizeToFit();
			nameLabel.Frame = new CGRect(padding, 15, nameLabel.Frame.Width, nameLabel.Frame.Height);

			startTime.Frame = new CGRect(padding, nameLabel.Frame.Bottom + 4, ContentView.Bounds.Width - padding*2, 0);
			startTime.SizeToFit();

			endTime.Frame = new CGRect(padding, startTime.Frame.Bottom + 2, ContentView.Bounds.Width - padding*2, 0);
			endTime.SizeToFit();
		}
	}
}

