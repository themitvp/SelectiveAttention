using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Travel.iOS
{
	[Register ("HomeCellId")]
	public class HomeTableCell : UITableViewCell
	{
		private UILabel arrivalLabel;

		public HomeTableCell (IntPtr p) : base (p)
		{
			BackgroundColor = UIColor.White;

			arrivalLabel = new UILabel () {
				Font = UIFont.FromName("HelveticaNeue", 22f),
				TextColor = UIColor.Black,
				AdjustsFontSizeToFitWidth = true
			};

			ContentView.AddSubview (arrivalLabel);
		}

		public void UpdateCell (MyEvent myevent)
		{
			arrivalLabel.Text = myevent.Arrival.ToString();
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			arrivalLabel.Frame = new CGRect (10, 0, ContentView.Bounds.Width - 20, ContentView.Bounds.Height);
		}
	}
}

