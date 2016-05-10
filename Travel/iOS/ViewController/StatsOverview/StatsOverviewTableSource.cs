using System;
using Foundation;
using System.Collections.ObjectModel;
using UIKit;

namespace Travel.iOS
{
	public class StatsOverviewTableSource : UITableViewSource
	{
		private StatsOverviewController parent;
		static NSString StatsOverviewCellId = new NSString ("StatsOverviewCellId");

		public StatsOverviewTableSource(StatsOverviewController parent)
		{
			TableItems = parent.statList;
			this.parent = parent;
		}

		void TableItems_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			this.parent._statsOverviewView.listTable.ReloadData();
		}

		public ObservableCollection<StatOverview> TableItems { get; set; }

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		// Changes the height of the row dynamically
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			var item = TableItems[indexPath.Row];

			if (item.StatType == StatTypes.TravelDistance) {
				return 300f;
			}

			return 84.6666666667f;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (StatsOverviewTableCell) tableView.DequeueReusableCell(StatsOverviewCellId, indexPath);

			var item = TableItems[indexPath.Row];

			// Add content to the cell
			cell.UpdateCell(item);

			if (item.StatType == StatTypes.TravelDistance) {
				cell.detailBtn.TouchUpInside += (sender, e) => {
					ViewStats(item);
				};
			}



			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var item = TableItems[indexPath.Row];

			ViewStats(item);

			tableView.DeselectRow(indexPath, true); // normal iOS behaviour is to remove the blue highlight
		}

		private void ViewStats(StatOverview item) {
			var viewController = new StatsViewController(item, parent);
			parent.NavigationController.PushViewController(viewController, true);
		}
	}
}

