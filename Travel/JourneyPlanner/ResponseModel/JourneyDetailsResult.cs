using System;
using JourneyPlanner.Infrastructure;
using JourneyPlanner.Model;

namespace JourneyPlanner
{
	public class JourneyDetailsResult : JourneyPlannerResponseBase
	{
		public JourneyDetailList JourneyDetail { get; set; }
	}
}

