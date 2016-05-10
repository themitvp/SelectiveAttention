using System;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace Travel.iOS
{
	public class StatsOverviewController : UIViewController
	{
		public StatsOverviewView _statsOverviewView;
		static NSString StatsOverviewCellId = new NSString ("StatsOverviewCellId");
		public ObservableCollection<StatOverview> statList { get; set; }
		public UIBarButtonItem filterBtn;

		public StatsOverviewController()
		{
			Title = "Stats";

			statList = new ObservableCollection<StatOverview> ();
		}

		public override void LoadView()
		{
			base.LoadView();

			_statsOverviewView = new StatsOverviewView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _statsOverviewView;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			BeginInvokeOnMainThread (delegate {
				_statsOverviewView.listTable.RegisterClassForCellReuse(typeof(StatsOverviewTableCell), StatsOverviewCellId);
				_statsOverviewView.listTable.Source = new StatsOverviewTableSource(this);
				_statsOverviewView.listTable.ReloadData();
			});
			Console.WriteLine(GlobalVariables.NSUserId);
			var response = HttpClientFramework.HttpResponseRepository.Get<StatOverviewWrapper>("http://dtupersonaldata2016.herokuapp.com", "api/v1.0/statistics/" + GlobalVariables.NSUserId + "/all").Result;
			if (response != null) {
				PopulateTable(response.Result);
			}
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.NavigationController.NavigationBar.BarTintColor = GlobalVariables.TravelTurkish;

			filterBtn = new UIBarButtonItem(UIImage.FromBundle("filter_all")
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
					options.Clicked += Options_Clicked;
			});
			
			this.NavigationItem.SetRightBarButtonItem(filterBtn, true);
		}

		void Options_Clicked (object sender, UIButtonEventArgs e)
		{
			string filterType = "all";

			if (e.ButtonIndex == 0) {
				filterBtn.Image = UIImage.FromBundle("filter_week");
				filterType = "week";
			} else if (e.ButtonIndex == 1) {
				filterBtn.Image = UIImage.FromBundle("filter_month");
				filterType = "month";
			} else if (e.ButtonIndex == 2) {
				filterBtn.Image = UIImage.FromBundle("filter_all");
				filterType = "all";
			}

			BeginInvokeOnMainThread(delegate {
				var response = HttpClientFramework.HttpResponseRepository.Get<StatOverviewWrapper>("http://dtupersonaldata2016.herokuapp.com", "api/v1.0/statistics/" + GlobalVariables.NSUserId + "/" + filterType).Result;
				if (response != null) {
					PopulateTable(response.Result);
				}
				_statsOverviewView.listTable.ReloadData();
			});
		}

		protected void PopulateTable(List<StatOverview> statOverviewList)
		{
			statList.Clear();

			foreach (var i in statOverviewList) {
				if (i.StatType == StatTypes.TravelDistance) {
					i.Id = 1;
				} else if (i.StatType == StatTypes.MostUsed) {
					i.Id = 2;
				} else if (i.StatType == StatTypes.TimeAtPlace) {
					i.Id = 3;
				} else if (i.StatType == StatTypes.Suggestion) {
					i.Id = 4;
				} else {
					i.Id = 0;
				}
			}

			statOverviewList =statOverviewList.OrderBy(x => x.Id).ToList();

			foreach (var i in statOverviewList) {
				if (i.Id != 0) {
					statList.Add(i);
				}
			}
		}
	}
}

