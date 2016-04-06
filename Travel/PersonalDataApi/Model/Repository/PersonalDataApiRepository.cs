using System;
using HttpClientFramework;

namespace PersonalDataApi
{
	public class PersonalDataApiRepository
	{
		private static string[] GenerateQuery<T>(T input) where T : RequestBase, IRequestBase
		{
			if (input == null)
				return null;

			var requestUrl = Constants.Endpoint[typeof(T)] + input.UrlEncode();

			return new string[]{ Constants.BaseUrl, requestUrl};
		}

		public static Y Get<T, Y> (T input) where T : RequestBase, IRequestBase where Y : ResponseBase
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
	}
}

