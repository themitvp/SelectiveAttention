using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.Collections.ObjectModel;
using System.Linq;

namespace Travel.iOS
{
	public class StatsViewController : UIViewController
	{
		public StatsView _statsView;
		static NSString StatsCellId = new NSString("StatsCellId");
		private StatsOverviewController parent;

		public ObservableCollection<MyStat> statList { get; set; }

		private StatOverview statOverview;

		public StatsViewController(StatOverview statOverview, StatsOverviewController parent)
		{
			Title = statOverview.Name;
			this.statOverview = statOverview;
			this.parent = parent;

			statList = new ObservableCollection<MyStat>();
		}

		public override void LoadView()
		{
			base.LoadView();

			_statsView = new StatsView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
			this.View = _statsView;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			BeginInvokeOnMainThread(delegate {
				_statsView.listTable.RegisterClassForCellReuse(typeof(StatsTableCell), StatsCellId);
				_statsView.listTable.Source = new StatsTableSource(this);
				_statsView.listTable.ReloadData();
			});
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			switch (this.statOverview.StatType) {
				case StatTypes.TravelDistance:
					GlobalVariables.CurrentStatsColor = parent.NavigationController.NavigationBar.BarTintColor = GlobalVariables.TravelGreenish;
					break;
				case StatTypes.MostUsed:
					GlobalVariables.CurrentStatsColor = parent.NavigationController.NavigationBar.BarTintColor = GlobalVariables.TravelGray;
					break;
				case StatTypes.TimeAtPlace:
					GlobalVariables.CurrentStatsColor = parent.NavigationController.NavigationBar.BarTintColor = GlobalVariables.TravelTurkish;
					break;
				case StatTypes.Suggestion:
					GlobalVariables.CurrentStatsColor = parent.NavigationController.NavigationBar.BarTintColor = GlobalVariables.TravelYellow;
					break;
			}

			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIImage.FromBundle("filter")
					, UIBarButtonItemStyle.Plain
					, (sender, args) => {
					// button was clicked
					var options = new UIActionSheet();
					options.Title = "Filter: Select period";
					options.AddButton("This Week");
					options.AddButton("This Month");
					options.AddButton("All");
					options.AddButton("Cancel");

					options.CancelButtonIndex = 3;  // black (Cancel)
					options.ShowInView(this.View);
				})
				, true);

			PopulateTable();
		}

		protected void PopulateTable()
		{
			statList.Clear();

			var travelTimeStat = new MyStat() {
				Number = 320,
				Metric = "min.",
				Description = "spent in public transport",
				StatType = StatTypes.TravelTime,
				TravelType = TravelTypes.PublicTransport
			};

			var travelDistanceStat = new MyStat() {
				Number = 27,
				Metric = "km",
				Description = "travelled by car",
				StatType = StatTypes.TravelDistance,
				TravelType = TravelTypes.Car
			};

			var travelDistanceStat1 = new MyStat() {
				Number = 40,
				Metric = "km",
				Description = "travelled by public transport",
				StatType = StatTypes.TravelDistance,
				TravelType = TravelTypes.PublicTransport
			};

			var travelDistanceStat2 = new MyStat() {
				Number = 82,
				Metric = "km",
				Description = "travelled by walk",
				StatType = StatTypes.TravelDistance,
				TravelType = TravelTypes.Walk
			};

			var travelDistanceStat3 = new MyStat() {
				Number = 77,
				Metric = "km",
				Description = "travelled by bicycle",
				StatType = StatTypes.TravelDistance,
				TravelType = TravelTypes.Bicycle
			};

			var travelDistanceStat4 = new MyStat() {
				Number = 34,
				Metric = "km",
				Description = "travelled by run",
				StatType = StatTypes.TravelDistance,
				TravelType = TravelTypes.Run
			};

			var delaysStat = new MyStat() {
				Number = 10,
				Metric = "delays",
				Description = "on your travels with public transport",
				StatType = StatTypes.Delays,
				TravelType = TravelTypes.PublicTransport
			};

			var delayHighScoreStat = new MyStat() {
				Number = 37,
				Metric = "%",
				Description = "you have met delays",
				StatType = StatTypes.DelayHighScore,
				TravelType = TravelTypes.PublicTransport
			};

			var mostUsedStat = new MyStat() {
				Number = 22,
				Metric = "times",
				Description = "you have travel between Home and DTU",
				StatType = StatTypes.MostUsed
			};

			var timeAtPlaceStat = new MyStat() {
				Number = 14,
				Metric = "days",
				Description = "spent at Home",
				StatType = StatTypes.TimeAtPlace,
				PlaceType = PlaceTypes.Home
			};

			var timeAtPlaceStat2 = new MyStat() {
				Number = 7,
				Metric = "days",
				Description = "spent at Work",
				StatType = StatTypes.TimeAtPlace,
				PlaceType = PlaceTypes.Work
			};

			var timeAtPlaceStat3 = new MyStat() {
				Number = 22,
				Metric = "days",
				Description = "spent at School",
				StatType = StatTypes.TimeAtPlace,
				PlaceType = PlaceTypes.School
			};

			var eachDayStat = new MyStat() {
				Number = 80,
				Metric = "%",
				Weekday = "Monday",
				Description = "of Mondays you are at DTU",
				StatType = StatTypes.EachDay
			};

			var suggestionStat = new MyStat() {
				Number = 15,
				Metric = "min.",
				Description = "could have been saved with bicycle instead of public transport",
				StatType = StatTypes.Suggestion,
				TravelType = TravelTypes.Bicycle
			};

			var funStat = new MyStat() {
				Number = 6132,
				Metric = "km",
				Description = "left and you have walked The Great Wall of China",
				StatType = StatTypes.Fun,
				TravelType = TravelTypes.Walk
			};

			switch (this.statOverview.StatType) {
				case StatTypes.TravelTime:
					statList.Add(travelTimeStat);
					break;
				case StatTypes.TravelDistance:
					statList.Add(travelDistanceStat);
					statList.Add(travelDistanceStat1);
					statList.Add(travelDistanceStat2);
					statList.Add(travelDistanceStat3);
					statList.Add(travelDistanceStat4);
					break;
				case StatTypes.MostUsed:
					statList.Add(mostUsedStat);
					break;
				case StatTypes.TimeAtPlace:
					statList.Add(timeAtPlaceStat);
					statList.Add(timeAtPlaceStat2);
					statList.Add(timeAtPlaceStat3);
					statList.Add(eachDayStat);
					break;
				case StatTypes.Suggestion:
					statList.Add(suggestionStat);
					statList.Add(funStat);
					break;
				case StatTypes.Delays:
					statList.Add(delaysStat);
					statList.Add(delayHighScoreStat);
					break;
			}

		}
	}
}

