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