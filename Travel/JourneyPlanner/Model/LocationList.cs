using System;
using System.Collections.Generic;

namespace JourneyPlanner.Model
{
	public class LocationList
	{
		public string NoNamespaceSchemaLocation { get; set; }

		public List<StopLocation> StopLocation { get; set; }

		public List<CoordLocation> CoordLocation { get; set; }
	}
}

