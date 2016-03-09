using JourneyPlanner.Infrastructure;

namespace JourneyPlanner.RequestModel
{
	public class JourneyDetailRequest : JourneyPlannerRequestBase
	{
		public string DepartureBoardUrl { get; set; }
	}
}

