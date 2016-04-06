using JourneyPlanner.Infrastructure;

namespace JourneyPlanner
{
	public class LocationRequest : JourneyPlannerRequestBase
	{
		public string Id { get; set; }

		public string Date { get; set; }

		public string Time { get; set; }

		public int? OffsetTime { get; set; }

		public int? UseTog { get; set; }

		public int? UseBus { get; set; }

		public int? UseMetro { get; set; }
	}
}

