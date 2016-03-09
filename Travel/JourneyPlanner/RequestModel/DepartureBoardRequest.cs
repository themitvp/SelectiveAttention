using JourneyPlanner.Infrastructure;

namespace JourneyPlanner.RequestModel
{
	public class DepartureBoardRequest : JourneyPlannerRequestBase
	{
		public int Id { get; set; }

		public string Date { get; set; }

		public string Time { get;set; }

		public int OffsetTine { get ; set; }

		public int UseTog { get; set; }

		public int UseBus { get; set; }

		public int UseMetro { get; set; }
	}
}

