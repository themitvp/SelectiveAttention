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
					var cont = (SearchResultTableController) searchController.SearchResultsController;

					if (cont.checkedMapItem != null && _addEventView.datePicker.Date != null && _addEventView.typeOfTransport.Text != null)
					{
						var date = (DateTime)_addEventView.datePicker.Date;
						date = date.AddHours(2);

						var newEvent = new MyEvent() {
							Arrival = date,
							Destination = cont.checkedMapItem.Name,
							Latitude = cont.checkedMapItem.Placemark.Coordinate.Latitude,
							Longitude = cont.checkedMapItem.Placemark.Coordinate.Longitude,
							TravelType = _addEventView.selectedTypeOfTransport
						};

						parent.SaveMyEvent(newEvent);

						this.NavigationController.PopViewController(true);
					}
				})
				, true);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			locationManager.RequestWhenInUseAuthorization ();

			var searchResultsController = new SearchResultTableController (this, _addEventView.direction);

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

			searchResultsController.DefinesPresentationContext = true;
			searchController.DefinesPresentationContext = true;
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

