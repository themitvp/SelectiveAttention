using System;
using System.Collections.Generic;

namespace PersonalDataApi
{
	internal class Constants
	{
		public const string BaseUrl = "http://dtupersonaldata2016.herokuapp.com/";

		public static Dictionary<Type, string> Endpoint = new  Dictionary<Type, string>
		{ 
			{ typeof(AuthenticationRequest), "api/v1.0/movesauthurl/" },
		};
	}
}

