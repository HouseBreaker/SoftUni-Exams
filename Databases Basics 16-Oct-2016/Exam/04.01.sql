-- solution start
CREATE PROC usp_SubmitReview @CustomerID INT, @ReviewContent NVARCHAR(255), @ReviewGrade INT, @AirlineName VARCHAR(30)
AS
SET XACT_ABORT ON
DECLARE @AirlineId INT = (SELECT AirlineID FROM Airlines WHERE AirlineName = @AirlineName);

IF (@AirlineId IS NULL)
BEGIN
	RAISERROR('Airline does not exist.', 16, 1);
	RETURN;
END

DECLARE @GeneratedReviewID INT = ISNULL((SELECT MAX(ReviewID) FROM CustomerReviews), 0) + 1;

BEGIN TRAN

BEGIN TRY
	INSERT INTO CustomerReviews (ReviewID, CustomerID, ReviewContent, ReviewGrade, AirlineID) VALUES
	(@GeneratedReviewID, @CustomerID, @ReviewContent, @ReviewGrade, @AirlineId)
	
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH
-- solution end
GO

EXEC usp_SubmitReview 1, 'love it', 5, 'Russia Airlines'
GO

SELECT * FROM CustomerReviews