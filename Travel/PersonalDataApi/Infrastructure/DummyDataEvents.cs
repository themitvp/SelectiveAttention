using System;
using System.Collections.Generic;
using Travel;

namespace PersonalDataApi
{
	public class DummyDataEvents
	{
		public DummyDataEvents()
		{
			var monday = new Tuple<string, List<MyEvent>>("Monday", new List<MyEvent>() {
				new MyEvent() {
					Name = "Home",
					StartTime = "08:00-08:10",
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
					StartTime = "07:00-07:10",
					EndTime = "07:50-08:00",
					PlaceType = PlaceTypes.Home
				},
				new MyEvent() {
					Name = "Nørrebrohallen",
					StartTime = "08:30-08:50",
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
					StartTime = "08:00-08:10",
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
					StartTime = "08:00-08:10",
					EndTime = "08:30-08:40",
					PlaceType = PlaceTypes.Home
				},
				new MyEvent() {
					Name = "DTU",
					StartTime = "09:00-09:10",
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
					StartTime = "08:00-08:10",
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
					StartTime = "08:00-08:10",
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
					StartTime = "08:00-08:10",
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
		}
	}
}

