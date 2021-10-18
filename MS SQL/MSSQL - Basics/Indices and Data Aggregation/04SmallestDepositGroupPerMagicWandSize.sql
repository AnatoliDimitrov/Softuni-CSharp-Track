SELECT TOP (2) [DepositGroup]
FROM
(SELECT [DepositGroup]
	,AVG([MagicWandSize]) AS [LongestMagicWand]
  FROM [WizzardDeposits]
  GROUP BY [DepositGroup]) AS d
ORDER BY [LongestMagicWand]