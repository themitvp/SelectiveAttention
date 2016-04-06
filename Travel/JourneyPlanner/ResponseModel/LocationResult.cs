using System;
using JourneyPlanner.Infrastructure;
using JourneyPlanner.Model;

namespace JourneyPlanner
{
	public class LocationResult : JourneyPlannerResponseBase
	{
		public LocationList LocationList { get; set; } 
	}
}

