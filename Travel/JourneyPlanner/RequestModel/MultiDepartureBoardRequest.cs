using JourneyPlanner.Infrastructure;

namespace JourneyPlanner
{
	public class MultiDepartureBoardRequest : JourneyPlannerRequestBase
	{
		public string Id1 { get; set; }

		public string Id2 { get; set; }

		public string Id3 { get; set; }

		public string Id4 { get; set; }

		public string Id5 { get; set; }

		public string Id6 { get; set; }

		public string Id7 { get; set; }

		public string Id8 { get; set; }

		public string Id9 { get; set; }

		public string Id10 { get; set; }

		public string Date { get; set; }

		public string Time { get;set; }

		public int? OffsetTine { get ; set; }

		public int? UseTog { get; set; }

		public int? UseBus { get; set; }

		public int? UseMetro { get; set; }
	}
}

