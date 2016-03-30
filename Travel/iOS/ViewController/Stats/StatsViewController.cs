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

			PopulateTable();
		}

		protected void PopulateTable()
		{
			statList.Clear();
			var statsDB = AppDelegate.Current.MyStatManager.GetMyStats().ToList();

			var newStat = new MyStat() {
				Number = 320,
				Metric = "min.",
				Description = "Spent on traveling",
				Type = MyStat.StatType.TimeSpent
			};

			var newStat2 = new MyStat() {
				Number = 60,
				Metric = "min.",
				Description = "Could have saved a lot of time if you went another route",
				Type = MyStat.StatType.TimeSaved
			};

			var newStat3 = new MyStat() {
				Number = 25,
				Metric = "min.",
				Description = "More in bed if you bike 5 km to work",
				Type = MyStat.StatType.Suggestion
			};

			statList.Add(newStat);
			statList.Add(newStat2);
			statList.Add(newStat3);

			foreach (var i in statsDB) {
				statList.Add(i);
			}
		}
	}
}

