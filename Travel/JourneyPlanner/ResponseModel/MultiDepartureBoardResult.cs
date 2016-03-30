using System;
using JourneyPlanner.Model;
using JourneyPlanner.Infrastructure;

namespace JourneyPlanner
{
	public class MultiDepartureBoardResult : JourneyPlannerResponseBase
	{
		public DepartureBoardList MultiDepartureBoard { get; set; }
	}
}

