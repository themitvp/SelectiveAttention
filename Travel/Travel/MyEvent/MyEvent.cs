using System;
using SQLite;

namespace Travel
{
	public enum TravelTypes {
		PublicTransport,
		Car,
		Walk,
		Bicycle,
		Run,
		Total
	}

	public class MyEvent : Item
	{
		public MyEvent () : base()
		{
		}

		/// <summary>
		/// Event name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Destination
		/// </summary>
		public string Destination { get; set; }

		/// <summary>
		/// Type of transportation
		/// </summary>
		public TravelTypes Type { get; set; }

		/// <summary>
		/// Latitude for destination
		/// </summary>
		public double Latitude { get; set; }

		/// <summary>
		/// Longitude for destination
		/// </summary>
		public double Longitude { get; set; }

		/// <summary>
		/// Date for arrival at destination
		/// </summary>
		public DateTime Arrival { get; set; }
	}
}

