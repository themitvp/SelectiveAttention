TravelTypesENUM {
	PublicTransport,
	Car,
	Walk,
	Bicycle,
	Run,
	Total
}

travel = {
	Traveltype : "WALK",
	TravelDistance : 20, #in meters
	TravelTime : 60, #seconds
	#Linenumber
}


myevents = [
{
	"Name" : "My Home",
	"Destination" : "Adressen 27, 2200 Byen",
	"Latitude" : 55.7861419709109,
	"Longitude" : 12.5240707397461,
	"StartTime" : "08:20-08:30", 
	"EndTime" : "12:20-12:30", 
	"TravelType" : [
		travel : travel
	]
	"PlaceTypes" : "Home"	# Home, Work, School, Other. NOT FROM API
}
]


myevents = [
	{
	"Monday" : [
		{
			"Name" : "My Home",
			"Destination" : "Adressen 27, 2200 Byen",
			"Latitude" : 55.7861419709109,
			"Longitude" : 12.5240707397461,
			"StartTime" : "08:20-08:30", 
			"EndTime" : "12:20-12:30", 
			"TravelType" : [
				travel : travel
			]
			"PlaceTypes" : "Home"	# Home, Work, School, Other. NOT FROM API
		},
		{
			"Name" : "My Work",
			"Destination" : "Adressen 27, 2200 Byen",
			"Latitude" : 55.7861419709109,
			"Longitude" : 12.5240707397461,
			"StartTime" : "08:20-08:30", 
			"EndTime" : "12:20-12:30", 
			"TravelType" : [
				travel : travel
			]
			"PlaceTypes" : "Work"	# Home, Work, School, Other. NOT FROM API
		},
	]
	},
	{
	"Tuesday" : [
		{
			...
		}
	]
	},
	{
	"Wednesday" : [
		{
			...
		}
	]
	},
]