SELECT [DepositGroup]
	,[IsDepositExpired]
	,AVG([DepositInterest]) AS [AverageInterest]
  FROM
	(SELECT *
	   FROM [WizzardDeposits]
	  WHERE [DepositStartDate] > '01-01-1985') AS d
 GROUP BY [DepositGroup], [IsDepositExpired]
 ORDER BY [DepositGroup] DESC--, [DepositExpirationDate]