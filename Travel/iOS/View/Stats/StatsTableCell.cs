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
		private UIView card;

		public StatsTableCell(IntPtr p) : base (p)
		{
			BackgroundColor = GlobalVariables.TravelLightGray;

			numberLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue", 45f)
			};

			metricsLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue", 45f)
			};

			descriptionLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue", 20f),
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0
			};

			icon = new UIImageView();

			card = new UIView();
			card.BackgroundColor = UIColor.White;

			// Add to Cell view
			ContentView.AddSubviews(new UIView[] {
				card,
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

			// Default Image
			icon.Image = UIImage.FromBundle("location");

			switch (stat.StatType) 
			{
			case StatTypes.TravelTime:
				//numberLabel.TextColor = GlobalVariables.TravelGreen;

				// Checking travel type
				switch (stat.TravelType) 
				{
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
				}
				break;
			case StatTypes.TravelDistance:
				//numberLabel.TextColor = GlobalVariables.TravelTurkish;
				icon.Image = UIImage.FromBundle("TimeSpent");
				break;
			case StatTypes.Fun:
				//numberLabel.TextColor = GlobalVariables.TravelGreenish;

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

			icon.Frame = new CGRect (ContentView.Bounds.Width - iconSize - padding, (ContentView.Bounds.Height - iconSize)/2, iconSize, iconSize);

			card.Frame = new CGRect(0, cardPadding, ContentView.Bounds.Width, ContentView.Bounds.Height - cardPadding);

			numberLabel.SizeToFit();
			numberLabel.Frame = new CGRect (padding, padding, numberLabel.Frame.Width, numberLabel.Frame.Height);

			metricsLabel.SizeToFit();
			metricsLabel.Frame = new CGRect (numberLabel.Frame.Right + padding/2, numberLabel.Frame.Y, metricsLabel.Frame.Width, metricsLabel.Frame.Height);

			descriptionLabel.Frame = new CGRect (padding, metricsLabel.Frame.Bottom + padding/2, icon.Frame.X - padding, 0);
			descriptionLabel.SizeToFit();
		}
	}
}

