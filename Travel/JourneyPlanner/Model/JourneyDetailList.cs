using System;
using System.Collections.Generic;

namespace JourneyPlanner.Model
{
	public class JourneyDetailList
	{
		public string NoNamespaceSchemaLocation { get; set; }

		public List<RouteDetail> Stop { get; set; } 

		public JourneyName JourneyName { get; set; }

		public JourneyType JourneyType { get; set; }

		public List<Note> Note { get; set; }
	}
}

