using System;
using System.Net.Http;
using ModernHttpClient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace HttpClientFramework
{
	public class HttpResponseRepository
	{
		public static async Task<T> Get<T> (string baseUrl, string endPoint)
		{
			try {
				HttpResponseMessage result;
				var client = new HttpClient (new NativeMessageHandler ()); 
				client.BaseAddress = new Uri (baseUrl);
				result = await client.GetAsync(endPoint).ConfigureAwait(false);
				var str = await result.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<T>(str);;
			} catch (Exception e) {
				
				var some = e.Message;
			
			}

			return default(T);
		}
	}
}



