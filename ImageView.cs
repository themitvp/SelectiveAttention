using System;
using UIKit;
using CoreGraphics;

namespace SelectiveAttention
{
	public class ImageView : UIView
	{
		// Subview properties
		public UIButton seeOriginalButton { get; set; }

		public ImageView(CGRect frame): base(frame)
		{

			this.BackgroundColor = UIColor.White;


			seeOriginalButton = UIButton.FromType(UIButtonType.System);
			seeOriginalButton.SetTitle("See Original", UIControlState.Normal);

			var buttonWidth = 100;
			var buttonHeight = 50;

			seeOriginalButton.Frame = new CGRect(buttonWidth, frame.Height - buttonHeight*2, buttonWidth, buttonHeight);

			this.AddSubview(seeOriginalButton);
		}
	}
}

