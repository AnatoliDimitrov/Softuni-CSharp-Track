CREATE PROC usp_CalculateFutureValueForAccount(@id INT, @interestRate FLOAT)
AS
	SELECT a.[Id] AS [Account Id]
	   ,a.[FirstName] AS [First Name]
	   ,a.[LastName] AS [Last Name]
	   ,d.[Balance] AS [Current Balance]
	   ,dbo.ufn_CalculateFutureValue(d.[Balance], @interestRate, 5) AS [Balance in 5 years]
FROM
	(SELECT ac.[AccountHolderId]
			,ac.[Balance] AS [Balance]
		FROM [AccountHolders] AS a
		JOIN [Accounts] AS ac ON a.[Id] = ac.[AccountHolderId]
		) AS d
JOIN [AccountHolders] AS a ON a.[Id] = d.[AccountHolderId]
WHERE a.[Id] = @id
GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1


SELECT a.[Id] AS [Account id]
	   ,a.[FirstName] AS [First Name]
	   ,a.[LastName] AS [Last Name]
	   ,d.[Balance] AS [Current Balance]
	   ,dbo.ufn_CalculateFutureValue(d.[Balance], 0.1, 5)
FROM
	(SELECT ac.[AccountHolderId]
			,ac.[Balance] AS [Balance]
		FROM [AccountHolders] AS a
		JOIN [Accounts] AS ac ON a.[Id] = ac.[AccountHolderId]
		) AS d
JOIN [AccountHolders] AS a ON a.[Id] = d.[AccountHolderId]
WHERE a.[Id] = 1