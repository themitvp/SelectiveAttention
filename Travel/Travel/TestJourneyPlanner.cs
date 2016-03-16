using System;
using JourneyPlanner.Model.Repository;
using JourneyPlanner.RequestModel;

namespace Travel
{
	public class TestJourneyPlanner
	{
		public string[] DoSomething ()
		{
			var journeyPlannerRepository = new JourneyPlanerRepository ();

			var request = new LocationRequest {
				Input = "Islands Brygge"
			};

			return  journeyPlannerRepository.GetLocation (request).Result;

		}
	}
}

