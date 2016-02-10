using System;
using UIKit;
using CoreGraphics;

namespace SelectiveAttention
{
	public class StartView : UIView
	{
		// Subview properties
		public UIButton startButton { get; set; }

		public StartView(CGRect frame): base(frame)
		{
			this.BackgroundColor = UIColor.White;


			startButton = UIButton.FromType(UIButtonType.System);
			startButton.SetTitle("START", UIControlState.Normal);

			var buttonWidth = 100;
			var buttonHeight = 50;

			startButton.Frame = new CGRect((frame.Width - buttonWidth)/2, (frame.Height - buttonHeight)/2, buttonWidth, buttonHeight);

			this.AddSubview(startButton);
		}
	}
}

