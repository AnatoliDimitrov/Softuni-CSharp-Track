CREATE PROC usp_GetTownsStartingWith(@StartString VARCHAR(100))
AS
	SELECT [Name] AS [Town]
	  FROM [Towns]
	 WHERE [Name] LIKE @StartString + '%'
GO

EXEC usp_GetTownsStartingWith 'B'