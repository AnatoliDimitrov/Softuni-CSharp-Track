CREATE PROC usp_EmployeesBySalaryLevel(@Level VARCHAR(10))
AS
	SELECT [FirstName] AS [First Name]
		   ,[LAstNAme] AS [Last Name]
	  FROM
		(SELECT *
			   ,dbo.ufn_GetSalaryLevel([Salary]) AS [Level]
		  FROM [Employees]) AS d
	 WHERE [Level] = @Level
GO

EXEC usp_EmployeesBySalaryLevel 'High'

