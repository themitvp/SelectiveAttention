using System;

namespace JourneyPlanner.Model
{
	public class Leg
	{
		public string Name { get; set; }

		public string Type {get;set;}

		public RouteDetail Origin { get; set; }

		public RouteDetail Destination { get; set; }

		public Note Notes { get; set; }

		public Reference JourneyDetailRef {get;set;}
	}
}

