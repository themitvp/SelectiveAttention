using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ModernHttpClient;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
/*
namespace Travel
{
	public sealed class ApiProxy
	{
		// URLs
		private const string BASE_URL = "https://api.nammy.eu";
		private const string BASE_URL_API = "/api";

		// Addons to other URLs
		private const string ADDON_URL_GET = "/get";
		private const string ADDON_URL_PROXIMITY = "/getproximityoffers";

		// Base URLs
		private const string BASE_URL_OFFER = BASE_URL_API + "/offer";


		private static readonly ApiProxy instance = new ApiProxy();
		private HttpClient client;
		//private JsonSerializerSettings deserializationSettings;

		private ApiProxy()
		{
			client = new HttpClient(new NativeMessageHandler());
			client.BaseAddress = new Uri(BASE_URL);

			//client.Timeout = 1;
			//deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
		}

		// API is used as a singleton
		public static ApiProxy Instance
		{
			get {
				return instance;
			}
		}

		private static string AddUrlParams(string baseUrl, Dictionary<string, object> parameters)
		{
			var stringBuilder = new StringBuilder(baseUrl);
			var hasFirstParam = baseUrl.Contains("?");

			foreach (var parameter in parameters)
			{
				var format = hasFirstParam ? "&{0}={1}" : "?{0}={1}";
				stringBuilder.AppendFormat(format, Uri.EscapeDataString(parameter.Key),
					Uri.EscapeDataString(parameter.Value.ToString()));
				hasFirstParam = true;
			}

			return stringBuilder.ToString();
		}

		public async Task<List<Offer>> GetProximityOffers(string latitude, string longitude, int page)
		{
			List<Offer> responseData = new List<Offer>();

			try {
				var response = await client.GetAsync(BASE_URL_OFFER + ADDON_URL_PROXIMITY);
				string content = await response.Content.ReadAsStringAsync();
				responseData = JsonConvert.DeserializeObject<List<Offer>>(content);
				return responseData;
			}
			catch (Exception e)
			{
				Debug.WriteLine("Error - Message: " + e.Message);
			}

			return new List<Offer>();
		}
	}
}
*/