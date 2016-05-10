using System;
using System.Collections.Generic;

namespace Travel
{
	public class StatOverview
	{
		public StatOverview()
		{
		}

		/// <summary>
		/// Name of stat overview
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of stat overview
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Different types of statistics
		/// </summary>
		public StatTypes? StatType { get; set; }

		/// <summary>
		/// Different types of statistics
		/// </summary
		public List<MyStat> Stats { get; set; }
	}
}

