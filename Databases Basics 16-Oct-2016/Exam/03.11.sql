SELECT a.AirportID, a.AirportName, AirportsPassengers.Passengers FROM
	(SELECT AirportID, COUNT(*) AS Passengers FROM Tickets t
	JOIN Flights f ON f.FlightID = t.FlightID
	JOIN Airports a ON a.AirportID = f.OriginAirportID
	WHERE f.Status = 'Departing'
	GROUP BY a.AirportID
	HAVING COUNT(*) > 0) AS AirportsPassengers
JOIN Airports a ON a.AirportID = AirportsPassengers.AirportID