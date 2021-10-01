SELECT DISTINCT
	DepartmentID
	,Salary AS [ThirdHighestSalary]
	--,[Partition]
FROM(SELECT *
		, DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Partition] 
  FROM [Employees]) AS p
WHERE [Partition] = 3
