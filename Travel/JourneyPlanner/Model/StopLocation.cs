using JourneyPlanner.Infrastructure;

namespace JourneyPlanner.Model
{
	public class StopLocation
	{
		public string Id { get; set;}
		public string Name { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Distance { get; set; }
	}
}

