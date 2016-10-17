SELECT
	t.TicketID,
	a.AirportName AS Destination,
	c.FirstName + ' ' + c.LastName AS CustomerName
FROM Tickets t
JOIN Flights f ON t.FlightID = f.FlightID
JOIN Customers c ON c.CustomerID = t.CustomerID
JOIN Airports a ON a.AirportID = f.DestinationAirportID
WHERE Class = 'First' AND Price < 5000
ORDER BY TicketID