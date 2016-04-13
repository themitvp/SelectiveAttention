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
		static NSString StatsCellId = new NSString ("StatsCellId");
		public ObservableCollection<MyStat> statList { get; set; }

		public StatsViewController()
		{
			Title = "Stats";

			statList = new ObservableCollection<MyStat> ();
		}

		public override void LoadView()
		{
			base.LoadView();

			_statsView = new StatsView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _statsView;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			BeginInvokeOnMainThread (delegate {
				_statsView.listTable.RegisterClassForCellReuse(typeof(StatsTableCell), StatsCellId);
				_statsView.listTable.Source = new StatsTableSource(this);
				_statsView.listTable.ReloadData();
			});
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIImage.FromBundle("filter")
					, UIBarButtonItemStyle.Plain
					, (sender,args) => {
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
			var statsDB = AppDelegate.Current.MyStatManager.GetMyStats().ToList();

			var newStat = new MyStat() {
				Number = 320,
				Metric = "min.",
				Description = "spent in public transport",
				StatType = StatTypes.TravelTime,
				TravelType = TravelTypes.PublicTransport
			};

			var newStat2 = new MyStat() {
				Number = 50,
				Metric = "km",
				Description = "travelled by car",
				StatType = StatTypes.TravelDistance,
				TravelType = TravelTypes.Car
			};

			var newStat3 = new MyStat() {
				Number = 10,
				Metric = "delays",
				Description = "on your travels with public transport",
				StatType = StatTypes.Delays,
				TravelType = TravelTypes.PublicTransport
			};

			var newStat4 = new MyStat() {
				Number = 37,
				Metric = "%",
				Description = "you have met delays",
				StatType = StatTypes.DelayHighScore,
				TravelType = TravelTypes.PublicTransport
			};

			var newStat5 = new MyStat() {
				Number = 22,
				Metric = "times",
				Description = "you have travel between Home and DTU",
				StatType = StatTypes.MostUsed
			};

			var newStat6 = new MyStat() {
				Number = 14,
				Metric = "days",
				Description = "spent at Home",
				StatType = StatTypes.TimeAtPlace
			};

			var newStat7 = new MyStat() {
				Number = 80,
				Metric = "%",
				Weekday = "Monday",
				Description = "of Mondays you are at DTU",
				StatType = StatTypes.EachDay
			};

			var newStat8 = new MyStat() {
				Number = 6132,
				Metric = "km",
				Description = "left and you have walked The Great Wall of China",
				StatType = StatTypes.Fun,
				TravelType = TravelTypes.Walk
			};

			statList.Add(newStat);
			statList.Add(newStat2);
			statList.Add(newStat3);
			statList.Add(newStat4);
			statList.Add(newStat5);
			statList.Add(newStat6);
			statList.Add(newStat7);
			statList.Add(newStat8);

			foreach (var i in statsDB) {
				statList.Add(i);
			}
		}
	}
}

