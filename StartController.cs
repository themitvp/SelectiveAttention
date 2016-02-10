using System;
using UIKit;
using CoreGraphics;

namespace SelectiveAttention
{
	public class StartController : UIViewController
	{
		// View
		private StartView _startView;

		public StartController()
		{
			Title = "Home";
		}

		public override void LoadView()
		{
			base.LoadView();

			_startView = new StartView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _startView;
		}

		public override void ViewDidLoad() 
		{
			_startView.startButton.TouchUpInside += (object sender, EventArgs e) => {
				Console.WriteLine("du har trykket på knappen!");
				//NavigationController.PushViewController(
			};
		}
	}
}

