using System;
using UIKit;
using CoreGraphics;
using CoreLocation;
using MapKit;

namespace Travel.iOS
{
	public class MapsViewController : UIViewController
	{
		// View
		private MapsView _mapView;
		private MyEvent myEvent;

		public MapsViewController(MyEvent myEvent)
		{
			Title = myEvent.Name;
			this.myEvent = myEvent;
		}

		public override void LoadView()
		{
			base.LoadView();

			_mapView = new MapsView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _mapView;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			if (myEvent.Latitude == 0) {
				myEvent.Latitude = 55.785592;
				myEvent.Longitude = 12.521360;
			}
			CLLocationCoordinate2D coords = new CLLocationCoordinate2D(myEvent.Latitude, myEvent.Longitude);

			MKCoordinateSpan span = new MKCoordinateSpan(KilometresToLatitudeDegrees(2), KilometresToLongitudeDegrees(2, coords.Latitude));

			this._mapView.map.Region = new MKCoordinateRegion(coords, span);
			var annotations = new MKPointAnnotation() {
				Title = myEvent.Name,
				Subtitle = myEvent.StartTime + " & " + myEvent.EndTime,
				Coordinate = coords
			};
			this._mapView.map.AddAnnotations (
				annotations
			);

			this._mapView.map.SelectAnnotation(annotations, true);
		}

		/// <summary>Converts kilometres to latitude degrees</summary>
		public double KilometresToLatitudeDegrees(double kms)
		{
			double earthRadius = 6371.0; // in kms
			double radiansToDegrees = 180.0/Math.PI;
			return (kms/earthRadius) * radiansToDegrees;
		}

		/// <summary>Converts kilometres to longitudinal degrees at a specified latitude</summary>
		public double KilometresToLongitudeDegrees(double kms, double atLatitude)
		{
			double earthRadius = 6371.0; // in kms
			double degreesToRadians = Math.PI/180.0;
			double radiansToDegrees = 180.0/Math.PI;
			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (kms / radiusAtLatitude) * radiansToDegrees;
		}
	}
}

