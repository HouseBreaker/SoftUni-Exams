SELECT TOP 5 AirlineID, AirlineName, Nationality, Rating FROM Airlines a
WHERE a.AirlineID IN
(SELECT DISTINCT AirlineID FROM Flights)
ORDER BY Rating DESC, AirlineID