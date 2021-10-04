CREATE PROC usp_GetEmployeesSalaryAboveNumber(@num DECIMAL(18, 4)) 
AS
	SELECT 
		   [FirstName] AS [First Name]
		   ,[LastName] AS [Last Name]
      FROM [Employees]
     WHERE [Salary] >= @num
GO
EXEC usp_GetEmployeesSalaryAboveNumber 35000