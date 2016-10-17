CREATE TABLE Flights
(
	FlightID INT PRIMARY KEY,
	DepartureTime DATETIME NOT NULL,
	ArrivalTime DATETIME NOT NULL,
	Status VARCHAR(9) CHECK(Status IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
	OriginAirportID INT FOREIGN KEY REFERENCES Airports(AirportID),
	DestinationAirportID INT FOREIGN KEY REFERENCES Airports(AirportID),
	AirlineID INT FOREIGN KEY REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets
(
	TicketID INT PRIMARY KEY,
	Price DECIMAL(8,2) NOT NULL,
	Class VARCHAR(6) CHECK (Class IN ('First', 'Second', 'Third')),
	Seat VARCHAR(5) NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
	FlightID INT FOREIGN KEY REFERENCES Flights(FlightID)
)