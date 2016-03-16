using System;
using System.Net.Http;
using ModernHttpClient;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientFramework
{
	public class HttpResponseRepository
	{
		public static async Task<T> Get<T> (string baseUrl, string endPoint)
		{
			var staticBaseUrl = "https://api.nammy.eu";
			var staticUrl = "/api/Offer/getproximityoffers?lat=55.676097&lng=12.568337&desiredCurrencyId=e41d6289ccd711e5bcc902d2a237d21d&page=0";

			try {
				HttpResponseMessage result;
				using (var client = new HttpClient (new NativeMessageHandler ())) {
					client.BaseAddress = new Uri (staticBaseUrl);
					result = await client.GetAsync (staticUrl);
				}

				var content = await result.Content.ReadAsStringAsync ();

				return JsonConvert.DeserializeObject<T> (content);
			} catch (Exception e) {
				
				var some = e.Message;
			
			}

			return default(T);
		}
	}
}



