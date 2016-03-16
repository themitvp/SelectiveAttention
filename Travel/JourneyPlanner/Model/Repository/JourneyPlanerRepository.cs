using System;
using System.Threading.Tasks;
using JourneyPlanner.RequestModel;
using JourneyPlanner.Infrastructure;

namespace JourneyPlanner.Model.Repository
{
	public class JourneyPlanerRepository
	{
		public async Task<ArrivalBoard> GetArrivalBoard (ArrivalBoardRequest input)
		{
			if (input == null)
				return null;

			var requestUrl = Constants.ArrivalBoardService.Endpoint + input.UrlEncode ();



			return new ArrivalBoard ();	
		}

		public async Task<DepartureBoard> GetDepartureBoard (DepartureBoardRequest input)
		{
			if (input == null)
				return null;

			var requestUrl = Constants.DepartureBoardService.Endpoint + input.UrlEncode ();

			return new DepartureBoard ();	
		}

		public async Task<JourneyDetail> GetJourneyDetail (JourneyDetailRequest input)
		{
			if (input == null)
				return null;

			var requestUrl = Constants.JourneyDetailService.Endpoint + input.UrlEncode ();

			return new JourneyDetail ();	
		}

		public async Task<string[]> GetLocation (LocationRequest input)
		{
			if (input == null)
				return null;

			var requestUrl = Constants.LocationService.Endpoint + input.UrlEncode ();

			return new string [] { Constants.BaseUrl, requestUrl };	
		}

		public async Task<MultiDepartureBoard> GetMultiDepartureBoard (MultiDepartureBoardRequest input)
		{
			if (input == null)
				return null;

			var requestUrl = Constants.MultiDepartureBoardService.Endpoint + input.UrlEncode ();

			return new MultiDepartureBoard ();	
		}

		public async Task<StopsNearby> GetStopsNearby (StopsNearbyRequest input)
		{
			if (input == null)
				return null;

			var requestUrl = Constants.StopsNearbyService.Endpoint + input.UrlEncode ();

			return new StopsNearby ();	
		}

		public async Task<string[]> GetTrip (TripRequest input)
		{
			if (input == null)
				return null;

			var requestUrl = Constants.TripService.Endpoint + input.UrlEncode ();


			return new string[]{ Constants.BaseUrl, requestUrl};
		}
	}
}

