using System;
using UIKit;
using CoreGraphics;

namespace SelectiveAttention
{
	public class ImageController : UIViewController
	{
		// View
		private ImageView _imageView;

		public ImageController()
		{
		}

		public override void LoadView()
		{
			base.LoadView();

			_imageView = new ImageView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _imageView;
		}

		public override void ViewDidLoad() 
		{
			
		}
	}
}

