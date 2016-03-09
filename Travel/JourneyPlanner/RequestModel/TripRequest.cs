namespace JourneyPlanner.RequestModel
{
	public class TripRequest
	{
		public int OriginId { get; set; }

		public int OriginCoordX { get; set; }

		public int OriginCoordY { get; set; }

		public string OriginCoordName { get; set; }

		public int DestId { get; set; }

		public int DestCoordX { get; set; }

		public int DestCoordY { get; set; }

		public string DestCoordName { get; set; }

		public int ViaId { get; set; }

		public string Date { get; set; }

		public string Time { get; set; }

		public int SearchForArrival { get; set; }

		public int UseTog { get; set; }

		public int UseBus { get; set; }

		public int UseMetro { get; set; }

		public int UseBicycle { get; set; }

		public int MaxWalkingDistanceDep { get; set; }

		public int MaxWalkingDistanceDest { get; set; }

		public int MaxCyclingDistanceDep { get; set; }

		public int MaxCyclingDistanceDest { get; set; }
	}
}

