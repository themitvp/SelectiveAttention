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

			PopulateTable();
		}

		void Options_Clicked (object sender, UIButtonEventArgs e)
		{
			if (e.ButtonIndex == 0) {
				filterBtn.Image = UIImage.FromBundle("filter_week");
			} else if (e.ButtonIndex == 1) {
				filterBtn.Image = UIImage.FromBundle("filter_month");
			} else if (e.ButtonIndex == 2) {
				filterBtn.Image = UIImage.FromBundle("filter_all");
			}

			BeginInvokeOnMainThread(delegate {
				//PopulateTable();
				_statsOverviewView.listTable.ReloadData();
			});
		}

		protected void PopulateTable()
		{
			statList.Clear();

			var travelTime = new StatOverview() {
				Name = "Travel Time",
				StatType = StatTypes.TravelTime,
				Stats = new List<MyStat> {
					new MyStat() {
						Number = 320,
						Metric = "min.",
						Description = "spent in public transport",
						StatType = StatTypes.TravelTime,
						TravelType = TravelTypes.PublicTransport
					}
				}
			};

			var travelDistance = new StatOverview() {
				Name = "Travel Distance",
				StatType = StatTypes.TravelDistance,
				Stats = new List<MyStat> {
					new MyStat() {
						Number = 27,
						Metric = "km",
						Description = "travelled by car",
						StatType = StatTypes.TravelDistance,
						TravelType = TravelTypes.Car
					},
					new MyStat() {
						Number = 40,
						Metric = "km",
						Description = "travelled by walk",
						StatType = StatTypes.TravelDistance,
						TravelType = TravelTypes.Walk
					},
					new MyStat() {
						Number = 82,
						Metric = "km",
						Description = "travelled by public",
						StatType = StatTypes.TravelDistance,
						TravelType = TravelTypes.PublicTransport
					},
					new MyStat() {
						Number = 77,
						Metric = "km",
						Description = "travelled by Bicycle",
						StatType = StatTypes.TravelDistance,
						TravelType = TravelTypes.Bicycle
					},
					new MyStat() {
						Number = 34,
						Metric = "km",
						Description = "travelled by run",
						StatType = StatTypes.TravelDistance,
						TravelType = TravelTypes.Run
					}
				}
			};

			var delays = new StatOverview() {
				Name = "Delays",
				StatType = StatTypes.Delays,
				Stats = new List<MyStat> {
					new MyStat() {
						Number = 10,
						Metric = "delays",
						Description = "on your travels with public transport",
						StatType = StatTypes.Delays,
						TravelType = TravelTypes.PublicTransport
					},
					new MyStat() {
						Number = 37,
						Metric = "%",
						Description = "you have met delays",
						StatType = StatTypes.DelayHighScore,
						TravelType = TravelTypes.PublicTransport
					}
				}
			};

			var mostUsed = new StatOverview() {
				Name = "Most Used",
				StatType = StatTypes.MostUsed,
				Stats = new List<MyStat> {
					new MyStat() {
						Number = 22,
						Metric = "times",
						Description = "you have travel between Home and DTU",
						StatType = StatTypes.MostUsed
					}
				}
			};
					
			var timeAtPlace = new StatOverview() {
				Name = "Locations",
				StatType = StatTypes.TimeAtPlace,
				Stats = new List<MyStat> {
					new MyStat() {
						Number = 14,
						Metric = "days",
						Description = "spent at Home",
						StatType = StatTypes.TimeAtPlace,
						PlaceType = PlaceTypes.Home
					},
					new MyStat() {
						Number = 7,
						Metric = "days",
						Description = "spent at Work",
						StatType = StatTypes.TimeAtPlace,
						PlaceType = PlaceTypes.Work
					},
					new MyStat() {
						Number = 22,
						Metric = "days",
						Description = "spent at School",
						StatType = StatTypes.TimeAtPlace,
						PlaceType = PlaceTypes.School
					},
					new MyStat() {
						Number = 80,
						Metric = "%",
						Weekday = "Monday",
						Description = "of Mondays you are at DTU",
						StatType = StatTypes.EachDay
					}
				}
			};

			var suggestion = new StatOverview() {
				Name = "Suggestions & Fun",
				StatType = StatTypes.Suggestion,
				Stats = new List<MyStat> {
					new MyStat() {
						Number = 15,
						Metric = "min.",
						Description = "could have been saved with bicycle instead of public transport",
						StatType = StatTypes.Suggestion,
						TravelType = TravelTypes.Bicycle
					},
					new MyStat() {
						Number = 6132,
						Metric = "km",
						Description = "left and you have walked The Great Wall of China",
						StatType = StatTypes.Fun,
						TravelType = TravelTypes.Walk
					}
				}
			};
				

			var statsoverviewlist = new List<StatOverview> {
				//travelTime,
				travelDistance,
				//delays,
				mostUsed,
				timeAtPlace,
				suggestion
			};


			foreach (var i in statsoverviewlist) {
				statList.Add(i);
			}
		}
	}
}

