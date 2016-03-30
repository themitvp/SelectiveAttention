using System;
using UIKit;
using Foundation;
using System.Collections.ObjectModel;

namespace Travel.iOS
{
	public class StatsTableSource : UITableViewSource
	{
		private StatsViewController parent;
		static NSString StatsCellId = new NSString ("StatsCellId");

		public StatsTableSource(StatsViewController parent)
		{
			TableItems = parent.statList;
			this.parent = parent;
		}

		void TableItems_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			this.parent._statsView.listTable.ReloadData();
		}

		public ObservableCollection<MyStat> TableItems { get; set; }

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		// Changes the height of the row dynamically
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 150f;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (StatsTableCell) tableView.DequeueReusableCell(StatsCellId, indexPath);

			var item = TableItems[indexPath.Row];

			// Add text to cell
			cell.UpdateCell(item);

			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine("In RowSelected");

			var item = TableItems[indexPath.Row];

			tableView.DeselectRow(indexPath, true); // normal iOS behaviour is to remove the blue highlight
		}
	}
}

