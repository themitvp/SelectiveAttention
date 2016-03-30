using System;
using JourneyPlanner.Infrastructure;
using JourneyPlanner.Model;

namespace JourneyPlanner
{
	public class StopsNearbyResult : JourneyPlannerResponseBase
	{
		public LocationListLite LocationList { get; set; }
	}
}

