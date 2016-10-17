SELECT DISTINCT
	c.CustomerID,
	c.FirstName + ' ' + c.LastName AS FullName,
	DATEDIFF(year, c.DateOfBirth, '20160101') AS Age
FROM Customers c
JOIN Tickets t ON t.CustomerID = c.CustomerID
JOIN Flights f ON f.FlightID = t.FlightID
WHERE f.Status = 'Departing'