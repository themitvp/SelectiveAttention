using System;
using Foundation;
using UIKit;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Travel.iOS
{
	public class HomeTableSource : UITableViewSource
	{
		private HomeViewController parent;
		static NSString HomeCellId = new NSString ("HomeCellId");
		public List<string> keys;

		public HomeTableSource(HomeViewController parent)
		{
			this.parent = parent;

			TableItems = parent.eventList;
			TableItems.CollectionChanged += TableItems_CollectionChanged;
		}

		void TableItems_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			this.parent._homeView.listTable.ReloadData();
		}

		public ObservableCollection<Tuple<string, List<MyEvent>>> TableItems { get; set; }

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems[(int)section].Item2.Count;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return TableItems.Count;
		}

		// Changes the height of the row dynamically
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 100f;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (HomeTableCell) tableView.DequeueReusableCell(HomeCellId, indexPath);

			var item = TableItems[indexPath.Section].Item2[indexPath.Row];

			// Add text to cell
			cell.UpdateCell(item);

			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var item = TableItems[indexPath.Section].Item2[indexPath.Row];

			var viewController = new MapsViewController(item);
			parent.NavigationController.PushViewController(viewController, true);

			tableView.DeselectRow(indexPath, true); // normal iOS behaviour is to remove the blue highlight
		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return TableItems[(int)section].Item1;
		}
	}
}

