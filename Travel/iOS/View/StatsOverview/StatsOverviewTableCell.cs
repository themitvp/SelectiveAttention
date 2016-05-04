using System;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;
using Xuni.iOS.Core;
using Xuni.iOS.ChartCore;
using Xuni.iOS.FlexPie;
using System.Linq;

namespace Travel.iOS
{
	[Register("StatsOverviewCellId")]
	public class StatsOverviewTableCell : UITableViewCell
	{
		private UILabel titleLabel, metricLabel;
		private UIImageView icon;
		private UIView card, sideBorder;
		private FlexPie flexPie;
		public UIButton detailBtn;

		public class BrowserUsageData : Foundation.NSObject
		{

			[Export("TravelTypeName")]
			public string TravelTypeName { get; set; }

			[Export("TravelNumber")]
			public double TravelNumber { get; set; }

			public BrowserUsageData(String name, double number)
			{
				TravelTypeName = name;
				TravelNumber = number;
			}
		}


		public NSMutableArray GetBrowserDataList()
		{
			NSMutableArray array = new NSMutableArray();
			string[] traveltype_names = new string[] { "Car", "Public Transport", "Walk", "Bicycle", "Run" };

			array.Add(new BrowserUsageData(traveltype_names[0], 27));
			array.Add(new BrowserUsageData(traveltype_names[1], 40));
			array.Add(new BrowserUsageData(traveltype_names[2], 82));
			array.Add(new BrowserUsageData(traveltype_names[3], 77));
			array.Add(new BrowserUsageData(traveltype_names[4], 34));

			return array;
		}


		public StatsOverviewTableCell(IntPtr p) : base(p)
		{
			BackgroundColor = GlobalVariables.TravelLightGray;
			SelectionStyle = UITableViewCellSelectionStyle.None;

			titleLabel = new UILabel() {
				Font = UIFont.FromName("HelveticaNeue-Thin", 30f),
				AdjustsFontSizeToFitWidth = true
			};

			metricLabel = new UILabel() {
				Font = UIFont.FromName("HelveticaNeue-Thin", 26f),
				Text = "km"
			};

			flexPie = new FlexPie();
			flexPie.Tag = 1;
			flexPie.ItemsSource = GetBrowserDataList();
			flexPie.Binding = "TravelNumber";
			flexPie.BindingName = "TravelTypeName";

			// set palette
			flexPie.Palette = XuniPalettes.Flatly();
			// configure flexpie settings
			flexPie.Header = "Distance";
			flexPie.HeaderFont = UIFont.FromName("HelveticaNeue-Thin", 30f);
			flexPie.InnerRadius = 0.6f;
			flexPie.StartAngle = 90f;
			flexPie.SelectedItemOffset = 0.1f;
			flexPie.SelectionMode = SelectionMode.SelectionModePoint;

			//// set data label

			flexPie.DataLabel.Content = (NSString)"{value}";
			flexPie.DataLabel.DataLabelBackgroundColor = UIColor.Clear;
			flexPie.DataLabel.DataLabelFontColor = UIColor.White;
			flexPie.DataLabel.DataLabelBorderColor = UIColor.Clear;
			flexPie.DataLabel.Position = PieDataLabelPosition.PieDataLabelPositionInside;
			flexPie.DataLabel.DataLabelFont = UIFont.FromName("HelveticaNeue", 18f);
			flexPie.DataLabel.DataLabelBorderWidth = 5f;

			flexPie.Legend.BorderColor = UIColor.Clear;


			//// customize tooltip
			flexPie.Tooltip.IsVisible = true;

			// configure animation
			flexPie.LoadAnimation.AnimationMode = AnimationMode.AnimationModePoint;

			detailBtn = UIButton.FromType(UIButtonType.Custom);
			detailBtn.BackgroundColor = UIColor.Clear;
			detailBtn.Font = UIFont.FromName("HelveticaNeue-Light", 12f);
			detailBtn.SetTitle("Details >", UIControlState.Normal);
			detailBtn.SetTitleColor(UIColor.Black, UIControlState.Normal);
			detailBtn.SetTitleColor(UIColor.FromRGB(87, 87, 87), UIControlState.Highlighted);

			icon = new UIImageView();

			card = new UIView();
			card.BackgroundColor = UIColor.White;

			sideBorder = new UIView();
			sideBorder.BackgroundColor = GlobalVariables.TravelTurkish;

			// Add to Cell view
			ContentView.AddSubviews(new UIView[] {
				card,
				sideBorder,
				titleLabel,
				icon,
				flexPie,
				detailBtn,
				metricLabel
			});
		}

		public void UpdateCell(StatOverview stat)
		{
			titleLabel.Text = stat.Name;

			// Check for type of statistic
			switch (stat.StatType) {
				case StatTypes.TravelTime:
					icon.Image = UIImage.FromBundle("clock");
					break;
				case StatTypes.TravelDistance:
					icon.Image = UIImage.FromBundle("location");
					sideBorder.BackgroundColor = GlobalVariables.TravelGreenish;
					break;
				case StatTypes.Delays:
				case StatTypes.DelayHighScore:
					icon.Image = UIImage.FromBundle("train");
					break;
				case StatTypes.MostUsed:
					icon.Image = UIImage.FromBundle("clock");
					sideBorder.BackgroundColor = GlobalVariables.TravelRed;
					break;
				case StatTypes.TimeAtPlace:
					icon.Image = UIImage.FromBundle("earth");
					sideBorder.BackgroundColor = GlobalVariables.TravelLightBlue;
					break;
				case StatTypes.EachDay:
					icon.Image = UIImage.FromBundle("calender");
					break;
				case StatTypes.Suggestion:
				case StatTypes.Fun:
					icon.Image = UIImage.FromBundle("great_wall");
					sideBorder.BackgroundColor = GlobalVariables.TravelYellow;
					break;
			}

			if (stat.StatType != StatTypes.TravelDistance) {
				flexPie.RemoveFromSuperview();
				detailBtn.RemoveFromSuperview();
				metricLabel.RemoveFromSuperview();
			} else {
				ContentView.BringSubviewToFront(icon);
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			var padding = 20;
			var iconSize = 50;
			var cardPadding = 5;
			var sideBorderWidth = 5;

			card.Frame = new CGRect(0, cardPadding, ContentView.Bounds.Width, ContentView.Bounds.Height - cardPadding);

			icon.Frame = new CGRect(ContentView.Bounds.Width - iconSize - padding, 19.83333f, iconSize, iconSize);

			sideBorder.Frame = new CGRect(0, card.Frame.Y, sideBorderWidth, card.Frame.Height);

			titleLabel.Frame = new CGRect(padding, card.Frame.Y, ContentView.Bounds.Width, card.Frame.Height);

			flexPie.Frame = new CGRect(5, padding, ContentView.Bounds.Width - 10, 300 - padding);

			detailBtn.Frame = new CGRect(ContentView.Bounds.Width - 80, 300 - 50, 80, 50);

			metricLabel.Frame = new CGRect(120, flexPie.Frame.Y, 70, flexPie.Frame.Height + 20);
		}
	}
}

