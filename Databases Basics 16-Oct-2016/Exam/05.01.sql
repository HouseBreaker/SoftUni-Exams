CREATE TABLE ArrivedFlights
(
	FlightID INT PRIMARY KEY,
	ArrivalTime DATETIME NOT NULL,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	Passengers INT NOT NULL
)
GO

-- solution start
CREATE TRIGGER tr_LogArrivals ON Flights
AFTER UPDATE
AS
BEGIN
	INSERT INTO ArrivedFlights (FlightID, ArrivalTime, Origin, Destination, Passengers)
	SELECT
		FlightsPassengers.FlightID,
		f.ArrivalTime,
		orig.AirportName AS Origin,
		dest.AirportName AS Destination,
		FlightsPassengers.Passengers
	FROM
		(SELECT i.FlightID, COUNT(TicketID) AS Passengers FROM inserted i
		LEFT JOIN Tickets t ON t.FlightID = i.FlightID
		GROUP BY i.FlightID) AS FlightsPassengers
	JOIN Flights f ON f.FlightID = FlightsPassengers.FlightID
	JOIN Airports orig ON orig.AirportID = f.OriginAirportID
	JOIN Airports dest ON dest.AirportID = f.DestinationAirportID
	WHERE f.Status = 'Arrived'
END
-- solution end

GO

SELECT * FROM Flights