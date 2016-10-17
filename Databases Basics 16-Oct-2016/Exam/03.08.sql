SELECT TOP 3
	c.CustomerID,
	c.FirstName + ' ' + c.LastName AS FullName,
	t.Price as TicketPrice,
	a.AirportName AS Destination
FROM Flights f
JOIN Tickets t ON t.FlightID = f.FlightID
JOIN Airports a ON a.AirportID = f.DestinationAirportID
JOIN Customers c ON c.CustomerID = t.CustomerID
WHERE f.Status = 'Delayed'
ORDER BY t.Price DESC, c.CustomerID