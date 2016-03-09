using System;
using System.Threading.Tasks;
using JourneyPlanner.RequestModel;
using JourneyPlanner.Infrastructure;

namespace JourneyPlanner.Model.Repository
{
	public class JourneyPlanerRepository
	{
		public async Task<ArrivalBoard> GetArrivalBoard(ArrivalBoardRequest input)
		{
			return new ArrivalBoard ();	
		}

		public async Task<DepartureBoard> GetDepartureBoard(DepartureBoardRequest input)
		{
			return new DepartureBoard ();	
		}

		public async Task<JourneyDetail> GetJourneyDetail(JourneyDetailRequest input)
		{
			return new JourneyDetail ();	
		}

		public async Task<Location> GetLocation(LocationRequest input)
		{
			return new Location ();	
		}

		public async Task<MultiDepartureBoard> GetMultiDepartureBoard(MultiDepartureBoardRequest input)
		{
			return new MultiDepartureBoard ();	
		}

		public async Task<StopsNearby> GetStopsNearby(StopsNearbyRequest input)
		{
			return new StopsNearby ();	
		}

		public string GetTrip(TripRequest input)
		{
			if (input == null)
				return null;

			var requestUrl = input.UrlEncode ();

			return requestUrl;
		}
	}
}

