using System;
using System.Threading.Tasks;
using JourneyPlanner.Infrastructure;
using HttpClientFramework;

namespace JourneyPlanner.Model.Repository
{
	public class JourneyPlanerRepository
	{
		private static string[] GenerateQuery<T>(T input) where T : JourneyPlannerRequestBase
		{
			if (input == null)
				return null;
			
			var requestUrl = JourneyPlannerEndpoint.Endpoint[typeof(T)] + input.UrlEncode ();

			return new string[]{ Constants.BaseUrl, requestUrl};
		}

		public static Y Get<T, Y> (T input) where T : JourneyPlannerRequestBase where Y : JourneyPlannerResponseBase
		{
			if (input == null)
				return null;

			var query = GenerateQuery<T> (input);

			var result = default(Y);

			try
			{
				result = HttpResponseRepository.Get<Y>(query[0], query[1]).Result;
			}
			catch(Exception e){
				
			}

			return result;
		}

		public static Y Get<Y> (string url) where Y : JourneyPlannerResponseBase
		{
			if (url == null)
				return null;

			var result = default(Y);

			var relPath = url.Remove (0, Constants.BaseUrl.Length);

			try
			{
				result = HttpResponseRepository.Get<Y>(Constants.BaseUrl, relPath).Result;
			}
			catch(Exception e){

			}

			return result;
		}
	}
}

