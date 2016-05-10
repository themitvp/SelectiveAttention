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

			statList = new ObservableCollection<MyStat>(statOverview.Stats);
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
					GlobalVariables.CurrentStatsColor = parent.NavigationController.NavigationBar.BarTintColor = GlobalVariables.TravelRed;
					break;
				case StatTypes.TimeAtPlace:
					GlobalVariables.CurrentStatsColor = parent.NavigationController.NavigationBar.BarTintColor = GlobalVariables.TravelLightBlue;
					break;
				case StatTypes.Suggestion:
					GlobalVariables.CurrentStatsColor = parent.NavigationController.NavigationBar.BarTintColor = GlobalVariables.TravelYellow;
					break;
			}

			this.NavigationItem.SetRightBarButtonItem(this.parent.filterBtn, true);
		}
	}
}

