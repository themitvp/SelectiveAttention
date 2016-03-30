using System;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;

namespace Travel.iOS
{
	public class PickerModel : UIPickerViewModel
	{
		public IList<Object> values;

		private int padding = 5;

		public event EventHandler<PickerChangedEventArgs> PickerChanged;

		public PickerModel(IList<Object> values)
		{
			this.values = values;
		}

		public override UIView GetView(UIPickerView picker, nint row, nint component, UIView view)
		{
			UILabel title = new UILabel(new CGRect(0, padding, picker.Frame.Width, 0));
			title.TextColor = UIColor.Black;
			title.Font = UIFont.FromName("HelveticaNeue", 25f);
			title.TextAlignment = UITextAlignment.Center;
			title.Text = values[(int)row].ToString();
			title.LineBreakMode = UILineBreakMode.WordWrap;
			title.Lines = 0;
			title.SizeToFit();
			return title;
		}

		public override nint GetComponentCount (UIPickerView picker)
		{
			return 1;
		}

		public override nint GetRowsInComponent (UIPickerView picker, nint component)
		{
			return values.Count;
		}

		public override string GetTitle (UIPickerView picker, nint row, nint component)
		{
			return values[(int)row].ToString();
		}

		public override nfloat GetRowHeight (UIPickerView picker, nint component)
		{
			UILabel title = new UILabel(new CGRect(0, padding, picker.Frame.Width, 0));
			title.Font = UIFont.FromName("HelveticaNeue", 25f);
			title.Text = values[(int)component].ToString();
			title.LineBreakMode = UILineBreakMode.WordWrap;
			title.Lines = 0;
			title.SizeToFit();
			return title.Frame.Height + padding;
		}

		public override void Selected (UIPickerView picker, nint row, nint component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new PickerChangedEventArgs{SelectedValue = values[(int)row]});
			}
		}
	}

	public class PickerChangedEventArgs : EventArgs{
		public object SelectedValue {get;set;}
	}
}

