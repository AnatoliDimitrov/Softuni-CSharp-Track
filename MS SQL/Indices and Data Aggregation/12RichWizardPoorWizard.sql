SELECT SUM([Difference]) AS [Difference] 
FROM
(SELECT f.[Id] AS [FirstId]
      ,f.[FirstName] AS [FirstColumn]
      ,f.[DepositAmount] AS [FirstDepositAmount]
	  ,s.[Id] AS [SecondId]
      ,s.[FirstName] AS [SecondColumn]
      ,s.[DepositAmount] AS [SecondDepositAmount]
	  ,f.DepositAmount - s.DepositAmount AS [Difference]
  FROM [WizzardDeposits] AS f
  JOIN [WizzardDeposits] AS s ON f.[Id] + 1 = s.[Id]) AS d
