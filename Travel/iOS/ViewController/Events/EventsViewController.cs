using System;
using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;
using Foundation;
using JourneyPlanner;
using JourneyPlanner.Model.Repository;
using PersonalDataApi;

using System.Linq;
using System.Collections.Generic;

namespace Travel.iOS
{
	public class EventsViewController : UIViewController
	{
		public EventsView _eventsView;
		static NSString EventsCellId = new NSString ("EventsCellId");
		public ObservableCollection<Tuple<string, List<MyEvent>>> eventsList { get; set; }


		public EventsViewController ()
		{
			Title = "Events";

			eventsList = new ObservableCollection<Tuple<string, List<MyEvent>>> ();
		}

		public override void LoadView()
		{
			base.LoadView();

			_eventsView = new EventsView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _eventsView;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender,args) => {
					// button was clicked
					this.NavigationController.PushViewController(new AddEventViewController(this), true);
				})
				, true);

			// Make the font in the status bar white
			//UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			//PopulateTable();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//OpenedFromNotification ();

			BeginInvokeOnMainThread (delegate {
				_eventsView.listTable.RegisterClassForCellReuse(typeof(EventsTableCell), EventsCellId);
				_eventsView.listTable.Source = new EventsTableSource(this);
				_eventsView.listTable.ReloadData();
			});

			var response = HttpClientFramework.HttpResponseRepository.Get<Dictionary<string, List<MyEvent>>>("http://dtupersonaldata2016.herokuapp.com", "api/v1.0/events/" + GlobalVariables.NSUserId + "/all").Result;
			if (response != null) {
				var data = response.Select(x => new Tuple<string, List<MyEvent>>(x.Key, x.Value)).ToList();
				PopulateTable(data);
			}
		}

		protected void PopulateTable(List<Tuple<string, List<MyEvent>>> myEventList)
		{
			eventsList.Clear();

			var dayIndex = new List<string> {"MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY"};

			var myEventListSorted = myEventList.OrderBy(x => dayIndex.IndexOf(x.Item1.ToUpper()));

			foreach (var i in myEventListSorted) {
				eventsList.Add(i);
			}
		}

		public void SaveMyEvent(MyEvent newMyEvent)
		{
			/*AppDelegate.Current.MyEventManager.SaveMyEvent(newMyEvent);

			var date1 = DateTime.Now;
			var seconds = (newMyEvent.Arrival - date1).TotalSeconds;

			// create the notification
			var notification = new UILocalNotification();

			// set the fire date (the date time in which it will fire)
			notification.FireDate = NSDate.FromTimeIntervalSinceNow(seconds);

			// configure the alert
			notification.AlertAction = "View My Event";
			notification.AlertBody = newMyEvent.Destination + " " + newMyEvent.Arrival.ToString();

			// modify the badge
			notification.ApplicationIconBadgeNumber = 1;

			// set the sound to be the default sound
			notification.SoundName = UILocalNotification.DefaultSoundName;

			// schedule it
			UIApplication.SharedApplication.ScheduleLocalNotification(notification);*/
		}

		public void OpenedFromNotification()
		{
			/*var tripRequestModel = new TripRequest {
				OriginId = "008603310",
				DestId = "000050100",
				Date = "30.03.16",
				Time = "13:00"
			};

			var departureBoardRequestModel = new DepartureBoardRequest {
				Id = "000050100",
				Date = "30.03.16",
				Time = "15:00"
			};

			var multiBoardRequestModel = new MultiDepartureBoardRequest {
				Id1 = "000050100",
				Id2 = "751446100",
				Id3 = "000046420",
				Date = "30.03.16",
				Time = "15:00"
			};

			var stopsNearbyRequest = new StopsNearbyRequest {
				CoordX = 12565796,
				CoordY = 55673063,
				MaxRadius = 1000,
				MaxNumber = 30
			};

			var journeyDetailsRequest = new JourneyDetailRequest
			{
				DepartureBoardUrl = "http://xmlopen.rejseplanen.dk/bin/rest.exe/journeyDetail?ref=775158%2F283931%2F38946%2F238941%2F86%3Fdate%3D30.03.16%26format%3Djson%26"
			};

				
			var trip = JourneyPlanerRepository.Get<TripRequest, TripResult> (tripRequestModel);

			var departureBoard = JourneyPlanerRepository.Get<DepartureBoardRequest, DepartureBoardResult> (departureBoardRequestModel);

			var multiDepartureBoard = JourneyPlanerRepository.Get<MultiDepartureBoardRequest, MultiDepartureBoardResult> (multiBoardRequestModel);

			var stopsNearby = JourneyPlanerRepository.Get<StopsNearbyRequest, StopsNearbyResult> (stopsNearbyRequest);

			var journeyDetails = JourneyPlanerRepository.Get<JourneyDetailsResult>(journeyDetailsRequest.DepartureBoardUrl);
			*/
		}
	}
}

