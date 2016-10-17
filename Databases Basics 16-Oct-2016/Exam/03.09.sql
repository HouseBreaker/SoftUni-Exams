SELECT TOP 5 
	f.FlightID,
	f.DepartureTime,
	f.ArrivalTime,
	origAirports.AirportName AS Origin,
	destAirports.AirportName AS Destination
FROM Flights f
JOIN Airports origAirports ON origAirports.AirportID = f.OriginAirportID
JOIN Airports destAirports ON destAirports.AirportID = f.DestinationAirportID
WHERE f.Status = 'Departing'
ORDER BY f.DepartureTime, f.FlightID