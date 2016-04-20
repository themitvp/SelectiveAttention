using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace Travel.iOS
{
	[Register ("StatsCellId")]
	public class StatsTableCell : UITableViewCell
	{
		private UILabel numberLabel, metricsLabel, descriptionLabel;
		private UIImageView icon;
		private UIView card, sideBorder;

		public StatsTableCell(IntPtr p) : base (p)
		{
			BackgroundColor = GlobalVariables.TravelLightGray;
			SelectionStyle = UITableViewCellSelectionStyle.None;

			numberLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue-Thin", 50f)
			};

			metricsLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue-Thin", 32f)
			};

			descriptionLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue", 18f),
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0
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
				numberLabel,
				metricsLabel,
				descriptionLabel,
				icon
			});
		}

		public void UpdateCell (MyStat stat)
		{
			numberLabel.Text = stat.Number.ToString();
			metricsLabel.Text = stat.Metric;
			descriptionLabel.Text = stat.Description;

			// Check travel type
			switch (stat.TravelType) {
			case TravelTypes.Car:
				icon.Image = UIImage.FromBundle("car");
				break;
			case TravelTypes.Walk:
			case TravelTypes.Run:
				icon.Image = UIImage.FromBundle("walking");
				break;
			case TravelTypes.Bicycle:
				icon.Image = UIImage.FromBundle("bike");
				break;
			case TravelTypes.PublicTransport:
				icon.Image = UIImage.FromBundle("train");
				break;
			default:
				icon.Image = UIImage.FromBundle("location");
				break;
			}

			// Check for type of statistic
			switch (stat.StatType) 
			{
			case StatTypes.TravelTime:
				// Border Color
				//sideBorder.BackgroundColor = GlobalVariables.TravelGreenish;
				break;
			case StatTypes.TravelDistance:
				// Border Color
				//sideBorder.BackgroundColor = GlobalVariables.TravelTurkish;
				break;
			case StatTypes.Delays:
			case StatTypes.DelayHighScore:
				icon.Image = UIImage.FromBundle("clock");
				break;
			case StatTypes.MostUsed:
				icon.Image = UIImage.FromBundle("mostUsed");
				break;
			case StatTypes.TimeAtPlace:
				//sideBorder.BackgroundColor = GlobalVariables.TravelTurkish;

				switch (stat.PlaceType) {
				case PlaceTypes.Home:
					icon.Image = UIImage.FromBundle("home");
					break;
				case PlaceTypes.Work:
					icon.Image = UIImage.FromBundle("work");
					break;
				case PlaceTypes.School:
					icon.Image = UIImage.FromBundle("school");
					break;
				}	
				break;
			case StatTypes.EachDay:
				icon.Image = UIImage.FromBundle("calender");
				break;
			case StatTypes.Fun:
				// Checking travel type
				switch (stat.TravelType) 
				{
				case TravelTypes.Walk:
				case TravelTypes.Run:
					icon.Image = UIImage.FromBundle("great_wall");
					break;
				case TravelTypes.Total:
					icon.Image = UIImage.FromBundle("earth");
					break;
				}
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

			icon.Frame = new CGRect (ContentView.Bounds.Width - iconSize - padding, padding, iconSize, iconSize);

			card.Frame = new CGRect(0, cardPadding, ContentView.Bounds.Width, ContentView.Bounds.Height - cardPadding);

			sideBorder.Frame = new CGRect(0, card.Frame.Y, sideBorderWidth, card.Frame.Height);

			numberLabel.SizeToFit();
			numberLabel.Frame = new CGRect (padding, padding, numberLabel.Frame.Width, numberLabel.Frame.Height);

			metricsLabel.SizeToFit();
			metricsLabel.Frame = new CGRect (numberLabel.Frame.Right + padding/2, numberLabel.Frame.Bottom - metricsLabel.Frame.Height - 3, metricsLabel.Frame.Width, metricsLabel.Frame.Height);

			descriptionLabel.Frame = new CGRect (padding+3, metricsLabel.Frame.Bottom + padding/2, ContentView.Bounds.Width - padding*2, 0);
			descriptionLabel.SizeToFit();
		}
	}
}

