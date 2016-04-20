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
		public TravelTypes? TravelType { get; set; }

		/// <summary>
		/// Latitude for destination
		/// </summary>
		public double Latitude { get; set; }

		/// <summary>
		/// Longitude for destination
		/// </summary>
		public double Longitude { get; set; }

		/// <summary>
		/// Start Time
		/// </summary>
		public string StartTime { get; set; }

		/// <summary>
		/// End Time
		/// </summary>
		public string EndTime { get; set; }

		/// <summary>
		/// Different types of places
		/// </summary>
		public PlaceTypes? PlaceType { get; set; }
	}
}

