using System;
using JourneyPlanner.Infrastructure;
using JourneyPlanner.Model;

namespace JourneyPlanner
{
	public class DepartureBoardResult : JourneyPlannerResponseBase
	{
		public DepartureBoardList DepartureBoard { get; set; }
	}
}

