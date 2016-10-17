SELECT DISTINCT
	c.CustomerID,
	c.FirstName + ' ' + c.LastName AS FullName,
	t.TownName AS HomeTown
FROM Customers c
JOIN Towns t ON c.HomeTownID = t.TownID
JOIN Tickets ti ON ti.CustomerID = c.CustomerID
JOIN Flights f ON f.FlightID = ti.FlightID
JOIN Airports a ON a.TownID = c.HomeTownID
WHERE f.OriginAirportID = a.AirportID