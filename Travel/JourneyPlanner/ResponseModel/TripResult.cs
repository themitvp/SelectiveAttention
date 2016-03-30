using System;
using JourneyPlanner.Infrastructure;
using JourneyPlanner.Model;

namespace JourneyPlanner
{
	public class TripResult : JourneyPlannerResponseBase
	{
		public TripList TripList { get; set; }
	}
}

