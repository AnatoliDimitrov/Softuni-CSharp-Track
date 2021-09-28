SELECT TOP (5) e.[EmployeeID]
	,e.[FirstName]
	,p.[Name]
  FROM [Employees] AS e
  LEFT JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
  LEFT JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
 WHERE ep.[EmployeeID] IS NOT NULL AND p.[StartDate] > '2002-08-13' AND p.[EndDate] IS NULL
 ORDER BY e.[EmployeeID]