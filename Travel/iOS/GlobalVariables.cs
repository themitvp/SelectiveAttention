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

		public static UIColor TravelGreenish = UIColor.FromRGB(118, 194, 175);

		public static UIColor TravelGray = UIColor.FromRGB(191, 191, 177);

		public static UIColor TravelLightBlue = UIColor.FromRGB(119, 179, 212);

		public static UIColor TravelYellow = UIColor.FromRGB(222, 171, 73); //245, 207, 135

		/// <summary>
		/// This should hold the current stats color, so all borders are colored with the same color
		/// </summary>
		public static UIColor CurrentStatsColor = GlobalVariables.TravelTurkish;

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

