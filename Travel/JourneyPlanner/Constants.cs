using System;

namespace JourneyPlanner
{
	internal class Constants
	{
		public const string BaseUrl = "http://xmlopen.rejseplanen.dk/bin/rest.exe/";

		public struct LocationService
		{
			public const string Endpoint = "location";
		}

		public struct TripService
		{
			public const string Endpoint = "trip";
		}

		public struct DepartureBoardService
		{
			public const string Endpoint = "departureBoard";
		}

		public struct ArrivalBoardService
		{
			public const string Endpoint = "arrivalBoard";
		}

		public struct MultiDepartureBoardService
		{
			public const string Endpoint = "multiDepartureBoard";
		}

		public struct StopsNearbyService
		{
			public const string Endpoint = "stopsNearBy";
		}

		public struct JourneyDetailService
		{
			public const string Endpoint = "journeyDetail";
		}
	}
}

