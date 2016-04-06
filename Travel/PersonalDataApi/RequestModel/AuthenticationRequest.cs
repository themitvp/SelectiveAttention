using System;
using System.Collections.Generic;

namespace PersonalDataApi
{
	public class AuthenticationRequest : RequestBase, IRequestBase
	{
		public Dictionary<string, string> NameDictionary(){
			return new Dictionary<string, string> {{"UserId",""}}; 
		}

		public Guid UserId { get; set; }
	}
}

