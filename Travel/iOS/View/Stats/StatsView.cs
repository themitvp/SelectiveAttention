using System;
using UIKit;
using CoreGraphics;

namespace Travel.iOS
{
	public class StatsView : UIView
	{
		// Subview properties
		public UITableView listTable { get; set; }

		public StatsView(CGRect frame): base(frame)
		{
			this.BackgroundColor = GlobalVariables.TravelLightGray;

			// Initialize & Setup
			listTable = new UITableView();
			listTable.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			listTable.ScrollsToTop = true;
			listTable.BackgroundColor = GlobalVariables.TravelLightGray;

			// Set frame
			listTable.Frame = new CGRect(0, 0, frame.Width, frame.Height);

			// Add subview
			this.AddSubview(listTable);
		}
	}
}

