﻿using System;
using UIKit;
using CoreGraphics;

namespace Travel.iOS
{
	public class HomeView : UIView
	{
		// Subview properties
		public UITableView listTable { get; set; }

		public HomeView(CGRect frame): base(frame)
		{
			this.BackgroundColor = UIColor.White;

			listTable = new UITableView();
			listTable.Frame = new CGRect(0, 0, frame.Width, frame.Height);
			listTable.ScrollsToTop = true;

			this.AddSubview(listTable);
		}
	}
}

