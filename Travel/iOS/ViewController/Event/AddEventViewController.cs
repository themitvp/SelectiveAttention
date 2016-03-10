using System;
using UIKit;
using CoreGraphics;
using Foundation;
using MapKit;
using System.Collections.ObjectModel;
using System.Linq;
using CoreLocation;

namespace Travel.iOS
{
	public class AddEventViewController : UIViewController
	{
		public AddEventView _addEventView;

		private HomeViewController parent;
		private UISearchController searchController;
		CLLocationManager locationManager = new CLLocationManager ();

		public AddEventViewController (HomeViewController parent)
		{
			Title = "Add Event";
			this.parent = parent;
		}

		public override void LoadView()
		{
			base.LoadView();

			_addEventView = new AddEventView(new CGRect(0,0,View.Frame.Width, View.Frame.Height), this);
			this.View = _addEventView;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender,args) => {
					// button was clicked
					var date = (DateTime)_addEventView.datePicker.Date;
					date = date.AddHours(1);

					var newEvent = new MyEvent() {
						Arrival = date
					};

					parent.eventList.Add(newEvent);

					Console.WriteLine(date);
					this.NavigationController.PopViewController(true);
				})
				, true);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			locationManager.RequestWhenInUseAuthorization ();

			var searchResultsController = new SearchResultTableController ();

			var searchUpdater = new SearchResultsUpdator ();
			searchUpdater.UpdateSearchResults += searchResultsController.Search;

			//add the search controller
			searchController = new UISearchController (searchResultsController) {
				SearchResultsUpdater = searchUpdater
			};

			searchController.SearchBar.SizeToFit ();
			searchController.DimsBackgroundDuringPresentation = false;
			searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;
			searchController.SearchBar.Placeholder = "Enter a search query";

			searchController.HidesNavigationBarDuringPresentation = false;
			_addEventView.searchResultTable.TableHeaderView = searchController.SearchBar;
			DefinesPresentationContext = true;
		}

		public class SearchResultsUpdator : UISearchResultsUpdating
		{
			public event Action<string> UpdateSearchResults = delegate {};

			public override void UpdateSearchResultsForSearchController (UISearchController searchController)
			{
				this.UpdateSearchResults (searchController.SearchBar.Text);
			}
		}
	}
}

