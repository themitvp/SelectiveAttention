using System;
using UIKit;
using CoreGraphics;

namespace Travel.iOS
{
	public class EventsView : UIView
	{
		// Subview properties
		public UITableView listTable { get; set; }

		public EventsView(CGRect frame): base(frame)
		{
			this.BackgroundColor = UIColor.White;

			// Initialize & Setup
			listTable = new UITableView();
			listTable.ScrollsToTop = true;

			// Set frame
			listTable.Frame = new CGRect(0, 0, frame.Width, frame.Height);

			// Add subview
			this.AddSubview(listTable);
		}
	}
}

