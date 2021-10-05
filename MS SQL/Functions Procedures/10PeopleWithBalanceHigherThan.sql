CREATE PROC usp_GetHoldersWithBalanceHigherThan(@num NUMERIC(15, 5))
AS
	SELECT [FirstName] AS [First Name]
	      ,[LastName] AS [Last Name]
      FROM
			(SELECT ac.[AccountHolderId]
				    ,SUM(ac.[Balance]) AS [Balance]
			   FROM [AccountHolders] AS a
			   JOIN [Accounts] AS ac ON a.[Id] = ac.[AccountHolderId]
			  GROUP BY ac.[AccountHolderId]) AS d
      JOIN [AccountHolders] AS a ON a.[Id] = d.[AccountHolderId]
     WHERE d.[Balance] > @num
     ORDER BY a.[FirstName], a.[LastName]
GO

EXEC usp_GetHoldersWithBalanceHigherThan 10000

SELECT *
  FROM
	(SELECT ac.[AccountHolderId]
		   ,SUM(ac.[Balance]) AS [Balance]
	  FROM [AccountHolders] AS a
	  JOIN [Accounts] AS ac ON a.[Id] = ac.[AccountHolderId]
	 GROUP BY ac.[AccountHolderId]) AS d
  JOIN [AccountHolders] AS a ON a.[Id] = d.[AccountHolderId]
  WHERE d.[Balance] > 10000
 ORDER BY a.[FirstName], a.[LastName]