SELECT 
	a.[EmployeeID]
	,a.[EmployeeName]
	,a.[ManagerName]
	,d.[Name] AS [DepartmentName]
FROM
	(SELECT TOP (50)
		e.[EmployeeID]
		,e.[EmployeeName]
		,m.[FirstName] + ' ' + m.[LastName] AS [ManagerName]
		,e.DepartmentID
	  FROM 
			(
				SELECT  
					[EmployeeID]
					,CONCAT([FirstName], ' ', [LastName]) AS [EmployeeName]
					,[ManagerID]
					,[DepartmentID]
				  FROM [Employees]
			) AS e
	  JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
	  ) AS a
JOIN [Departments] AS d ON a.DepartmentID = d.DepartmentID
  ORDER BY a.EmployeeID