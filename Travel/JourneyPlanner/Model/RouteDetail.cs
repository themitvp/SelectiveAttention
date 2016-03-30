using System;

namespace JourneyPlanner
{
	public class RouteDetail
	{
		public string Name { get; set; }

		public string Type { get;set; }

		public int RouteIdx { get; set; }

		public string Time { get; set; }

		public string Date { get; set; }

		public int? X { get; set; }

		public int? Y { get; set; }

		public string ArrTime { get; set; }

		public string ArrDate { get; set; }

		public string DepTime { get; set; }

		public string DepDate { get; set; }
	}
}

