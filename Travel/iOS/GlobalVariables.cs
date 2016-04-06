using System;
using UIKit;
using Foundation;

namespace Travel.iOS
{
	public class GlobalVariables : Application
	{
		public static UIColor TravelLightGray = UIColor.FromRGB(0xed, 0xed, 0xed); // #EDEDED

		public static UIColor TravelGreen = UIColor.FromRGB(0x25, 0x9b, 0x24);

		public static UIColor TravelRed = UIColor.FromRGB(0xe5, 0x1c, 0x23); //

		public static UIColor TravelBlue = UIColor.FromRGB(0x3f, 0x51, 0xb5); //#3f51b5

		public static UIColor TravelTurkish = UIColor.FromRGB(32, 118, 155);

		public static UIColor TravelGreenish = UIColor.FromRGB(99, 184, 159);

		private const string UserId = "UserId";

		/// <summary>
		/// The id of the user
		/// </summary>
		public static string NSUserId { 
			get { 
				return NSUserDefaults.StandardUserDefaults.StringForKey(UserId); 
			}
			set { 
				NSUserDefaults.StandardUserDefaults.SetString(value, UserId);
			}
		}
	}
}

