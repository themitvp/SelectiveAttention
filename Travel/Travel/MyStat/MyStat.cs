using System;
using SQLite;

namespace Travel
{
	public enum StatTypes {
		TravelTime,
		TravelDistance,
		Delays,
		DelayHighScore,
		MostUsed,
		TimeAtPlace,
		EachDay,
		Suggestion,
		Fun
	}

	public enum PlaceTypes {
		Home,
		Work,
		School
	}

	public class MyStat : Item
	{
		public MyStat() : base()
		{
		}

		/// <summary>
		/// Stat metric
		/// </summary>
		public string Metric { get; set; }

		/// <summary>
		/// Stat number
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// Stat description
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Stat description
		/// </summary>
		public string Weekday { get; set; }

		/// <summary>
		/// Different types of transportation
		/// </summary>
		public TravelTypes? TravelType  { get; set; }

		/// <summary>
		/// Different types of statistics
		/// </summary>
		public StatTypes? StatType { get; set; }

		/// <summary>
		/// Different types of places
		/// </summary>
		public PlaceTypes? PlaceType { get; set; }

	}
}

