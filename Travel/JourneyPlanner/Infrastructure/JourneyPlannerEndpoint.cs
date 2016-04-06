using System;
using System.Collections.Generic;
namespace JourneyPlanner
{
	public class JourneyPlannerEndpoint 
	{
		public static Dictionary<Type, string> Endpoint = new  Dictionary<Type, string>
		{ 
			{ typeof(TripRequest), "trip" },
			{ typeof(LocationRequest), "location" },
			{ typeof(DepartureBoardRequest), "departureBoard" },
			{ typeof(ArrivalBoardRequest), "arrivalBoard" },
			{ typeof(MultiDepartureBoardRequest), "multiDepartureBoard" },
			{ typeof(StopsNearbyRequest), "stopsNearby" },
			{ typeof(JourneyDetailRequest), "" }
		};
	}
}
	