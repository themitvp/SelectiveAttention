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
				Description = "Spent in public transport",
				StatType = StatTypes.TravelTime,
				TravelType = TravelTypes.PublicTransport
			};

			var newStat2 = new MyStat() {
				Number = 60,
				Metric = "min.",
				Description = "Could have saved a lot of time if you went another route",
				StatType = StatTypes.TravelTime,
				TravelType = TravelTypes.Bicycle
			};

			var newStat3 = new MyStat() {
				Number = 6532,
				Metric = "km",
				Description = "left and you have walked The Great Wall of China",
				StatType = StatTypes.Fun,
				TravelType = TravelTypes.Walk
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

