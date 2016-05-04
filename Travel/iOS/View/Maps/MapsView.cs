using System;
using UIKit;
using CoreGraphics;
using MapKit;
using CoreLocation;

namespace Travel.iOS
{
	public class MapsView : UIView
	{
		// Subview properties
		public MKMapView map;

		public MapsView(CGRect frame): base(frame)
		{
			this.BackgroundColor = GlobalVariables.TravelLightGray;

			map = new MKMapView();

			map.Frame = new CGRect(0, 0, frame.Width, frame.Height);

			// Add Subviews
			this.AddSubview(map);
		}
	}
}

