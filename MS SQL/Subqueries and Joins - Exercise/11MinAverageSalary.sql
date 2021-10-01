SELECT TOP (1) AVG(e.Salary)
  FROM [Employees] AS e
 GROUP BY e.[DepartmentID]
 ORDER BY AVG(e.Salary)