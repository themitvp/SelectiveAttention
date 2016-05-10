using System;
using Foundation;
using UIKit;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using SWTableViewCells;

namespace Travel.iOS
{
	public class EventsTableSource : UITableViewSource
	{
		private EventsViewController parent;
		static NSString EventsCellId = new NSString ("EventsCellId");
		public List<string> keys;
		private CellDelegate cellDelegate;

		public EventsTableSource(EventsViewController parent)
		{
			this.parent = parent;

			TableItems = parent.eventsList;
			TableItems.CollectionChanged += TableItems_CollectionChanged;

			cellDelegate = new CellDelegate(TableItems, parent._eventsView.listTable);
		}

		void TableItems_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			this.parent._eventsView.listTable.ReloadData();
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
			tableView.RowHeight = 100f;

			var cell = (EventsTableCell) tableView.DequeueReusableCell(EventsCellId);

			var item = TableItems[indexPath.Section].Item2[indexPath.Row];

			if (cell.Delegate == null) {
				cell.Delegate = cellDelegate;
				cell.SetRightUtilityButtons (RightButtons (), 80.0f);
			}
			cell.SeparatorInset = new UIEdgeInsets(0, 0, 0, 0);

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

		static UIButton[] RightButtons ()
		{
			NSMutableArray rightUtilityButtons = new NSMutableArray ();
			rightUtilityButtons.AddUtilityButton (GlobalVariables.TravelGray, "Edit");
			rightUtilityButtons.AddUtilityButton (GlobalVariables.TravelRed, "Delete");
			return NSArray.FromArray<UIButton> (rightUtilityButtons);
		}

		class CellDelegate : SWTableViewCellDelegate
		{
			private readonly UITableView tableView;
			private readonly ObservableCollection<Tuple<string, List<MyEvent>>> tableItems;

			public CellDelegate (ObservableCollection<Tuple<string, List<MyEvent>>> tableItems, UITableView tableView)
			{
				this.tableItems = tableItems;
				this.tableView = tableView;
			}

			public override void ScrollingToState (SWTableViewCell cell, SWCellState state)
			{
				switch (state) {
					case SWCellState.Center:
						Console.WriteLine ("utility buttons closed");
						break;
					case SWCellState.Left:
						Console.WriteLine ("left utility buttons open");
						break;
					case SWCellState.Right:
						Console.WriteLine ("right utility buttons open");
						break;
				}
			}

			public override void DidTriggerLeftUtilityButton (SWTableViewCell cell, nint index)
			{
				Console.WriteLine ("Left button {0} was pressed.", index);

				new UIAlertView ("Left Utility Buttons", string.Format ("Left button {0} was pressed.", index), null, "OK", null).Show ();
			}

			public override void DidTriggerRightUtilityButton (SWTableViewCell cell, nint index)
			{
				Console.WriteLine ("Right button {0} was pressed.", index);

				switch (index) {
					case 0:
						// More button was pressed
						Console.WriteLine ("Edit button was pressed");
						cell.HideUtilityButtons (true);
						break;
					case 1:
						tableView.BeginUpdates();
						// Delete button was pressed
						NSIndexPath cellIndexPath = tableView.IndexPathForCell(cell);
						tableItems[cellIndexPath.Section].Item2.RemoveAt(cellIndexPath.Row);
						if (tableItems[cellIndexPath.Section].Item2.Count > 0) {
							tableView.DeleteRows(new[] { cellIndexPath }, UITableViewRowAnimation.Left);
						} else {
							tableItems.RemoveAt(cellIndexPath.Section);
							tableView.DeleteSections(NSIndexSet.FromIndex(cellIndexPath.Section), UITableViewRowAnimation.Left);
						}
						tableView.EndUpdates();
						break;
				}
			}

			public override bool ShouldHideUtilityButtonsOnSwipe (SWTableViewCell cell)
			{
				// allow just one cell's utility button to be open at once
				return true;
			}

			public override bool CanSwipeToState (SWTableViewCell cell, SWCellState state)
			{
				switch (state) {
					case SWCellState.Left:
						// set to false to disable all left utility buttons appearing
						return false;
					case SWCellState.Right:
						// set to false to disable all right utility buttons appearing
						return true;
				}
				return true;
			}
		}
	}
}

