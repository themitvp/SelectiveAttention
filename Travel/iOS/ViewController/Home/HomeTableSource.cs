using System;
using Foundation;
using UIKit;
using System.Collections.ObjectModel;

namespace Travel.iOS
{
	public class HomeTableSource : UITableViewSource
	{
		private HomeViewController parent;
		string HomeCellId = "HomeId";

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

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (HomeCellId);

			if (cell == null) {
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, HomeCellId);
			}

			cell.TextLabel.Text = TableItems[indexPath.Row].Destination;
 			cell.DetailTextLabel.Text = TableItems[indexPath.Row].Arrival.ToString();

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

