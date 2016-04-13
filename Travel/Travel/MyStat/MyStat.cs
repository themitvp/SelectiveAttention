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
		Fun
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
		/// Stat description
		/// </summary>
		public TravelTypes TravelType  { get; set; }

		/// <summary>
		/// Different types
		/// </summary>
		public StatTypes StatType { get; set; }
	}
}

