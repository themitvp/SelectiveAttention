﻿using System;
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
	public class HomeViewController : UIViewController
	{
		public HomeView _homeView;
		static NSString HomeCellId = new NSString ("HomeCellId");
		public ObservableCollection<Tuple<string, List<MyEvent>>> eventList { get; set; }


		public HomeViewController ()
		{
			Title = "Events";

			eventList = new ObservableCollection<Tuple<string, List<MyEvent>>> ();
		}

		public override void LoadView()
		{
			base.LoadView();

			_homeView = new HomeView(new CGRect(0,0,View.Frame.Width, View.Frame.Height));
			this.View = _homeView;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			/*this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender,args) => {
					// button was clicked
					this.NavigationController.PushViewController(new AddEventViewController(this), true);
				})
				, true);*/

			// Make the font in the status bar white
			//UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			PopulateTable();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//OpenedFromNotification ();

			BeginInvokeOnMainThread (delegate {
				_homeView.listTable.RegisterClassForCellReuse(typeof(HomeTableCell), HomeCellId);
				_homeView.listTable.Source = new HomeTableSource(this);
				_homeView.listTable.ReloadData();
			});
		}

		protected void PopulateTable()
		{
			eventList.Clear();


			var monday = new Tuple<string, List<MyEvent>>("Monday", new List<MyEvent>() {
				new MyEvent() {
					Name = "Home",
					StartTime = "8:00-8:10",
					EndTime = "12:20-12:50",
					PlaceType = PlaceTypes.Home,
					Latitude = 55.75613006732355,
					Longitude = 12.520766258239746
				},
				new MyEvent() {
					Name = "DTU",
					StartTime = "13:20-13:30",
					EndTime = "16:50-17:10",
					PlaceType = PlaceTypes.School,
					Latitude = 55.785592,
					Longitude = 12.521360
				},
				new MyEvent() {
					Name = "Home",
					StartTime = "17:30-18:00",
					EndTime = "23:00-23:10",
					PlaceType = PlaceTypes.Home,
					Latitude = 55.75613006732355,
					Longitude = 12.520766258239746
				}
			});

			var tuesday = new Tuple<string, List<MyEvent>>("Tuesday", new List<MyEvent>() {
				new MyEvent() {
					Name = "Home",
					StartTime = "7:00-7:10",
					EndTime = "7:50-8:00",
					PlaceType = PlaceTypes.Home
				},
				new MyEvent() {
					Name = "Nørrebrohallen",
					StartTime = "8:30-8:50",
					EndTime = "10:00-10:20"
				},
				new MyEvent() {
					Name = "Ørnevej 2",
					StartTime = "10:30-10:40",
					EndTime = "17:00-17:10"
				},
				new MyEvent() {
					Name = "Home",
					StartTime = "17:30-18:00",
					EndTime = "23:00-23:10",
					PlaceType = PlaceTypes.Home
				}
			});

			var wednesday = new Tuple<string, List<MyEvent>>("Wednesday", new List<MyEvent>() {
				new MyEvent() {
					Name = "Home",
					StartTime = "8:00-8:10",
					EndTime = "12:20-12:50",
					PlaceType = PlaceTypes.Home
				},
				new MyEvent() {
					Name = "DTU",
					StartTime = "13:20-13:30",
					EndTime = "16:50-17:10",
					PlaceType = PlaceTypes.School
				},
				new MyEvent() {
					Name = "Home",
					StartTime = "17:30-18:00",
					EndTime = "23:00-23:10",
					PlaceType = PlaceTypes.Home
				}
			});

			var thursday = new Tuple<string, List<MyEvent>>("Thursday", new List<MyEvent>() {
				new MyEvent() {
					Name = "Home",
					StartTime = "8:00-8:10",
					EndTime = "8:30-8:40",
					PlaceType = PlaceTypes.Home
				},
				new MyEvent() {
					Name = "DTU",
					StartTime = "9:00-9:10",
					EndTime = "11:40-12:10",
					PlaceType = PlaceTypes.School
				},
				new MyEvent() {
					Name = "Work",
					StartTime = "12:40-13:00",
					EndTime = "17:00-17:20",
					PlaceType = PlaceTypes.Work
				},
				new MyEvent() {
					Name = "Home",
					StartTime = "12:40-13:00",
					EndTime = "17:00-17:20",
					PlaceType = PlaceTypes.Work
				}
			});

			var friday = new Tuple<string, List<MyEvent>>("Friday", new List<MyEvent>() {
				new MyEvent() {
					Name = "Home",
					StartTime = "8:00-8:10",
					EndTime = "12:20-12:50",
					PlaceType = PlaceTypes.Home
				},
				new MyEvent() {
					Name = "DTU",
					StartTime = "13:20-13:30",
					EndTime = "16:50-17:10",
					PlaceType = PlaceTypes.School
				},
				new MyEvent() {
					Name = "Home",
					StartTime = "17:30-18:00",
					EndTime = "23:00-23:10",
					PlaceType = PlaceTypes.Home
				}
			});

			var saturday = new Tuple<string, List<MyEvent>>("Saturday", new List<MyEvent>() {
				new MyEvent() {
					Name = "Home",
					StartTime = "8:00-8:10",
					EndTime = "12:20-12:50",
					PlaceType = PlaceTypes.Home
				},
				new MyEvent() {
					Name = "DTU",
					StartTime = "13:20-13:30",
					EndTime = "16:50-17:10",
					PlaceType = PlaceTypes.School
				},
				new MyEvent() {
					Name = "Home",
					StartTime = "17:30-18:00",
					EndTime = "23:00-23:10",
					PlaceType = PlaceTypes.Home
				}
			});
			var sunday = new Tuple<string, List<MyEvent>>("Sunday", new List<MyEvent>() {
				new MyEvent() {
					Name = "Home",
					StartTime = "8:00-8:10",
					EndTime = "12:20-12:50",
					PlaceType = PlaceTypes.Home
				},
				new MyEvent() {
					Name = "DTU",
					StartTime = "13:20-13:30",
					EndTime = "16:50-17:10",
					PlaceType = PlaceTypes.School
				},
				new MyEvent() {
					Name = "Home",
					StartTime = "17:30-18:00",
					EndTime = "23:00-23:10",
					PlaceType = PlaceTypes.Home
				}
			});

			eventList.Add(monday);
			eventList.Add(tuesday);
			eventList.Add(wednesday);
			eventList.Add(thursday);
			eventList.Add(friday);
			eventList.Add(saturday);
			eventList.Add(sunday);


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

