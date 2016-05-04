StatTypesENUM {
	TravelTime,
	TravelDistance,
	Delays,
	DelayHighScore,
	MostUsed,
	TimeAtPlace,
	EachDay,
	Suggestion,
	Fun
}

TravelTypesENUM {
	PublicTransport,
	Car,
	Walk,
	Bicycle,
	Run,
	Total
}

PlaceTypesENUM {
	Home,
	Work,
	School
}

statsOverviewList = [
	{
		"Name" : "Travel Time", # Title
		"StatType" : "TravelTime",
		"Stats" : [
			{	
				"Number" : 320,
				"Metric" : "min.",
				"Description" : "spent in [public transport]",
				"StatType" : "TravelTime",
				"TravelType" : "PublicTransport"	# All traveltypes
			},
			# All belonging stats for traveltime
			...
		]
	},
	{
		"Name" : "Travel Distance", # Title
		"StatType" : "TravelDistance",
		"Stats" : [
			{	
				"Number" : 50,
				"Metric" : "km",
				"Description" : "travelled by [car]",
				"StatType" : "TravelDistance",
				"TravelType" : "Car"	# All traveltypes
			},
			{	
				"Number" : 32,
				"Metric" : "km",
				"Description" : "travelled by [bicycle]",
				"StatType" : "TravelDistance",
				"TravelType" : "Bicycle"	# All traveltypes
			},
			# All belonging stats for traveldistance
			...
		]
	},
	{
		"Name" : "Delays", # Title
		"StatType" : "Delays", # Delays or DelayHighScore it doesn't matter
		"Stats" : [
			{	
				"Number" : 10,
				"Metric" : "delays",
				"Description" : "on your travels with public transport",
				"StatType" : "Delays",
				"TravelType" : "PublicTransport"	# Only PublicTransport
			},
			{	
				"Number" : 37,
				"Metric" : "%",
				"Description" : "you have met delays",
				"StatType" : "DelayHighScore",
				"TravelType" : "PublicTransport"	# Only PublicTransport
			},
			# All belonging stats for Delays and DelayHighScore
			...
		]
	},
	{
		"Name" : "Most Used", # Title
		"StatType" : "MostUsed", # Delays or DelayHighScore it doesn't matter
		"Stats" : [
			{	
				"Number" : 67,
				"Metric" : "times",
				"Description" : "you have travel between [locationA] and [locationB]",
				"StatType" : "MostUsed",
				"TravelType" : ""	# Not used yet
			},
			# All belonging stats for MostUsed
			...
		]
	},
	{
		"Name" : "Locations", # Title
		"StatType" : "TimeAtPlace",
		"Stats" : [
			{	
				"Number" : 14,
				"Metric" : "days",
				"EventName" : "My Home",	# Linked to MyEvent
				"Description" : "spent at [location]",
				"StatType" : "TimeAtPlace",
				"TravelType" : ""	# Not used
			},
			{
				"Number" : 80,
				"Metric" : "%",
				"EventName" : "My Home",	# Linked to MyEvent
				"Weekday" : "Monday",
				"Description" : "of all Mondays you spent at [location]",
				"StatType" : "EachDay",
				"TravelType" : ""	# Not used
			}
			# All belonging stats for TimeAtPlace and EachDay
			...
		]
	},
	{
		"Name" : "Suggestions & Fun", # Title
		"StatType" : "Suggestion",
		"Stats" : [
			{	
				"Number" : 15,
				"Metric" : "min.",
				"Description" : "could have been saved with bicycle instead of public transport",
				"StatType" : "Suggestion",
				"TravelType" : "Bicycle"
			},
			{
				"Number" : 6132,	#TOTAL: 6430 km
				"Metric" : "km",
				"Description" : "left and you have walked The Great Wall of China",
				"StatType" : "Fun",
				"TravelType" : "Walk"	# Walk, Run and Total traveltypes
			}
			# All belonging stats for Suggestion and Fun
			...
		]
	}
]
