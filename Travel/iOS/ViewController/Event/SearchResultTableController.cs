using System;
using Foundation;
using UIKit;
using System.Collections.ObjectModel;
using MapKit;
using System.Collections.Generic;
using System.Linq;

namespace Travel.iOS
{
	public class SearchResultTableController : UITableViewController
	{
		static NSString SearchCellId = new NSString ("SearchCellId");

		public List<MKMapItem> MapItems { get; set; }

		public NSIndexPath checkedCell;

		public SearchResultTableController()
		{
			MapItems = new List<MKMapItem> ();
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return MapItems.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			
			var cell = tableView.DequeueReusableCell (SearchCellId);

			if (cell == null)
				cell = new UITableViewCell ();
			
			cell.TextLabel.Text = MapItems[indexPath.Row].Name;

			if (checkedCell != null && checkedCell.IsEqual (indexPath)) {
				cell.Accessory = UITableViewCellAccessory.Checkmark;
			} else {
				cell.Accessory = UITableViewCellAccessory.None;
			}

			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine("In RowSelected");

			if (checkedCell != null) {
				tableView.CellAt (checkedCell).Accessory = UITableViewCellAccessory.None;

			}
			if (checkedCell != null && checkedCell.IsEqual (indexPath)) {
				checkedCell = null;
			} else {
				tableView.CellAt (indexPath).Accessory = UITableViewCellAccessory.Checkmark; 
				checkedCell = indexPath;
			}

			var item = MapItems[indexPath.Row];

			tableView.DeselectRow(indexPath, true); // normal iOS behaviour is to remove the blue highlight
		}

		public void Search (string forSearchString) {
			// create search request
			var searchRequest = new MKLocalSearchRequest ();
			searchRequest.NaturalLanguageQuery = forSearchString;

			// perform search
			var localSearch = new MKLocalSearch (searchRequest);

			localSearch.Start (delegate (MKLocalSearchResponse response, NSError error) {
				if (response != null && error == null) {
					this.MapItems = response.MapItems.ToList ();
					this.TableView.ReloadData ();
				} else {
					Console.WriteLine ("local search error: {0}", error);
				}
			});
		}
	}
}

