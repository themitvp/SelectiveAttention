using System;
using SQLite;

namespace Travel
{
	public class MyEvent : Item
	{
		public MyEvent () : base()
		{
		}

		public enum TravelType {
			PublicTransport,
			Car,
			Walking,
			Bicycling,
			Running
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
		public TravelType Type { get; set; }

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

