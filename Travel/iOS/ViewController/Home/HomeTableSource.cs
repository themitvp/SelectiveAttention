using System;
using Foundation;
using UIKit;
using System.Collections.ObjectModel;

namespace Travel.iOS
{
	public class HomeTableSource : UITableViewSource
	{
		private HomeViewController parent;
		static NSString HomeCellId = new NSString ("HomeCellId");

		public HomeTableSource(HomeViewController parent)
		{
			TableItems = parent.eventList;
			this.parent = parent;

			TableItems.CollectionChanged += TableItems_CollectionChanged;
		}

		void TableItems_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			this.parent._homeView.listTable.ReloadData();
		}

		public ObservableCollection<MyEvent> TableItems { get; set; }

		public override nint RowsInSection(UITableView tableview, nint section)
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

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return "Monday";
		}
	}
}

