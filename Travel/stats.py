StatTypes {
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

TravelTypes {
	PublicTransport,
	Car,
	Walk,
	Bicycle,
	Run,
	Total
}

PlaceTypes {
	Home,
	Work,
	School
}

Stats = [
{
	"Number" : 320,
	"Metric" : "min.",
	"Description" : "spent in public transport",
	"StatType" : "TravelTime",
	"TravelType" : "PublicTransport"	# All traveltypes
},
{
	"Number" : 50,
	"Metric" : "km",
	"Description" : "travelled by car",
	"StatType" : "TravelDistance",
	"TravelType" : "Car"	# All traveltypes
},
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
{
	"Number" : 67,
	"Metric" : "times",
	"Description" : "you have travel between [locationA] and [locationB]",
	"StatType" : "MostUsed",
	"TravelType" : ""	# Not used
},
{
	"Number" : 14,
	"Metric" : "days",
	"PlaceTypes" : "Home",	# Home, Work or School.
	"Description" : "spent at [location]",
	"StatType" : "TimeAtPlace",
	"TravelType" : ""	# Not used
},
{
	"Number" : 80,
	"Metric" : "%",
	"PlaceTypes" : "Home",	# Home, Work or School.
	"Weekday" : "Monday",
	"Description" : "of all Mondays you spent at [location]",
	"StatType" : "EachDay",
	"TravelType" : ""	# Not used
},
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
]
