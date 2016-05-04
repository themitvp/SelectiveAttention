using System;
using UIKit;
using CoreGraphics;

namespace Travel.iOS
{
	public class StatsOverviewView : UIView
	{
		// Subview properties
		public UITableView listTable { get; set; }
		public UICollectionView collection { get; set; }

		public StatsOverviewView(CGRect frame): base(frame)
		{
			this.BackgroundColor = GlobalVariables.TravelLightGray;

			//collection = new UICollectionView();
			//collection.Frame = new CGRect(0, 0, frame.Width, 200);

			// Initialize & Setup
			listTable = new UITableView();
			listTable.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			listTable.ScrollsToTop = true;
			listTable.BackgroundColor = GlobalVariables.TravelLightGray;

			// Set frame
			listTable.Frame = new CGRect(0, 0, frame.Width, frame.Height);

			// Add subview
			//this.AddSubview(collection);
			this.AddSubview(listTable);
		}
	}
}

