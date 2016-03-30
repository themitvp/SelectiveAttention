using System;
using SQLite;

namespace Travel
{
	public class MyStat : Item
	{
		public MyStat() : base()
		{
		}

		public enum StatType {
			TimeSpent,
			TimeSaved,
			Overcame,
			CouldSave,
			Suggestion,
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
		/// Different types
		/// </summary>
		public StatType Type { get; set; }
	}
}

