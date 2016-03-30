using System;

namespace JourneyPlanner.Model
{
	public class DepartureBoard
	{
		public string Name { get; set; }

		public string Type { get; set; }

		public string Stop { get; set; }

		public string Time { get; set; }

		public string Date { get; set; }

		public string Messages { get; set; }

		public string RtTime { get; set; }

		public string RtDate { get; set; }

		public string FinalStop { get; set; }

		public string Direction { get; set; }

		public Reference JourneyDetailRef { get; set; }

	}
}

