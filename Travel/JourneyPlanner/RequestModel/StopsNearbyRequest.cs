﻿using JourneyPlanner.Infrastructure;

namespace JourneyPlanner
{
	public class StopsNearbyRequest : JourneyPlannerRequestBase
	{
		public int? CoordX { get; set; }

		public int? CoordY { get; set; }

		public int? MaxRadius { get; set; }

		public int? MaxNumber { get; set; }
	}
}

