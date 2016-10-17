UPDATE Tickets
SET Tickets.Price += Tickets.Price * 0.5
WHERE FlightID IN
	(SELECT FlightID FROM Flights f
	JOIN Airlines a ON f.AirlineID = a.AirlineID
	WHERE f.AirlineID =
		(SELECT AirlineID FROM Airlines
		WHERE Rating = (SELECT MAX(Rating) FROM Airlines)))
