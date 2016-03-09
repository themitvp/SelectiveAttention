using System;

namespace Travel
{
	public class MyEvent
	{
		public MyEvent ()
		{
		}

		/// <summary>
		/// Id
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Event name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Destination
		/// </summary>
		public string Destination { get; set; }

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

