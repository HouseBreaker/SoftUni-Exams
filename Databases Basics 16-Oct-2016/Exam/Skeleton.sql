CREATE DATABASE Airport
GO

USE Airport
GO

CREATE TABLE Towns (
	TownID INT,
	TownName VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY(TownID)
)

CREATE TABLE Airports (
	AirportID INT,
	AirportName VARCHAR(50) NOT NULL,
	TownID INT NOT NULL,
	CONSTRAINT PK_Airports PRIMARY KEY(AirportID),
	CONSTRAINT FK_Airports_Towns FOREIGN KEY(TownID) REFERENCES Towns(TownID)
)

CREATE TABLE Airlines (
	AirlineID INT,
	AirlineName VARCHAR(30) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Rating INT DEFAULT(0),
	CONSTRAINT PK_Airlines PRIMARY KEY(AirlineID)
)

CREATE TABLE Customers (
	CustomerID INT,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Gender VARCHAR(1) NOT NULL CHECK (Gender='M' OR Gender='F'),
	HomeTownID INT NOT NULL,
	CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
	CONSTRAINT FK_Customers_Towns FOREIGN KEY(HomeTownID) REFERENCES Towns(TownID)
)

INSERT INTO Towns(TownID, TownName)
VALUES
(1, 'Sofia'),
(2, 'Moscow'),
(3, 'Los Angeles'),
(4, 'Athene'),
(5, 'New York')

INSERT INTO Airports(AirportID, AirportName, TownID)
VALUES
(1, 'Sofia International Airport', 1),
(2, 'New York Airport', 5),
(3, 'Royals Airport', 1),
(4, 'Moscow Central Airport', 2)

INSERT INTO Airlines(AirlineID, AirlineName, Nationality, Rating)
VALUES
(1, 'Royal Airline', 'Bulgarian', 200),
(2, 'Russia Airlines', 'Russian', 150),
(3, 'USA Airlines', 'American', 100),
(4, 'Dubai Airlines', 'Arabian', 149),
(5, 'South African Airlines', 'African', 50),
(6, 'Sofia Air', 'Bulgarian', 199),
(7, 'Bad Airlines', 'Bad', 10)

INSERT INTO Customers(CustomerID, FirstName, LastName, DateOfBirth, Gender, HomeTownID)
VALUES
(1, 'Cassidy', 'Isacc', '19971020', 'F', 1),
(2, 'Jonathan', 'Half', '19830322', 'M', 2),
(3, 'Zack', 'Cody', '19890808', 'M', 4),
(4, 'Joseph', 'Priboi', '19500101', 'M', 5),
(5, 'Ivy', 'Indigo', '19931231', 'F', 1)

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

INSERT INTO Flights (FlightID, DepartureTime, ArrivalTime, Status, OriginAirportID, DestinationAirportID, AirlineID) VALUES 
(1, '20161013 06:00 AM', '20161013 10:00 AM', 'Delayed', 1, 4, 1),
(2, '20161012 12:00 PM', '20161012 12:01 PM', 'Departing', 1, 3, 2),
(3, '20161014 03:00 PM', '20161020 04:00 AM', 'Delayed', 4, 2, 4),
(4, '20161012 01:24 PM', '20161012 4:31 PM', 'Departing', 3, 1, 3),
(5, '20161012 08:11 AM', '20161012 11:22 PM', 'Departing', 4, 1, 1),
(6, '19950621 12:30 PM', '19950622 08:30 PM', 'Arrived', 2, 3, 5),
(7, '20161012 11:34 PM', '20161013 03:00 AM', 'Departing', 2, 4, 2),
(8, '20161111 01:00 PM', '20161112 10:00 PM', 'Delayed', 4, 3, 1),
(9, '20151001 12:00 PM', '20151201 01:00 AM', 'Arrived', 1, 2, 1),
(10, '20161012 07:30 PM', '20161013 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES

(1, 3000.00, 'First', '233-A', 3, 8),
(2, 1799.90, 'Second', '123-D', 1, 1),
(3, 1200.50, 'Second', '12-Z', 2, 5),
(4, 410.68, 'Third', '45-Q', 2, 8),
(5, 560.00, 'Third', '201-R', 4, 6),
(6, 2100.00, 'Second', '13-T', 1, 9),
(7, 5500.00, 'First', '98-O', 2, 7)

CREATE TABLE CustomerReviews
(
	ReviewID INT PRIMARY KEY,
	ReviewContent NVARCHAR(255) NOT NULL,
	ReviewGrade INT CHECK (ReviewGrade BETWEEN 0 AND 10),
	AirlineID INT FOREIGN KEY REFERENCES Airlines(AirlineID),
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts
(
	AccountID INT PRIMARY KEY,
	AccountNumber VARCHAR(10) NOT NULL UNIQUE,
	Balance DECIMAL(10, 2) NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

INSERT INTO CustomerReviews (ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID) VALUES
(1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
(2, 'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
(3, 'Meh...', 5, 4, 3),
(4, 'Well I''ve seen better, but I''ve certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts (AccountID, AccountNumber, Balance, CustomerID) VALUES
(1, '123456790', 2569.23, 1),
(2, '18ABC23672', 14004568.23, 2),
(3, 'F0RG0100N3', 19345.20, 5)