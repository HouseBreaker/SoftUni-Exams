
-- solution start
CREATE PROC usp_PurchaseTicket @CustomerID INT, @FlightID INT, @TicketPrice DECIMAL(8,2), @Class VARCHAR(6), @Seat VARCHAR(5)
AS
SET XACT_ABORT ON
BEGIN
	DECLARE @GeneratedTicketID INT = ISNULL((SELECT MAX(TicketID) FROM Tickets), 0) + 1;
	
	DECLARE @UserBalance DECIMAL(10, 2) = (SELECT Balance FROM CustomerBankAccounts WHERE CustomerID = @CustomerID)

	IF (@TicketPrice > @UserBalance)
	BEGIN
		RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
		RETURN;
	END

	BEGIN TRY
		UPDATE CustomerBankAccounts
		SET Balance -= @TicketPrice
		WHERE CustomerID = @CustomerID
		
		INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES
		(@GeneratedTicketID, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH
END

-- solution end
GO

EXEC usp_PurchaseTicket 1, 2, 30000, 'Second', '202-A'

SELECT * FROM CustomerBankAccounts
SELECT * FROM Tickets