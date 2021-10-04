CREATE PROC usp_GetEmployeesFromTown(@town VARCHAR(100)) 
AS
	SELECT 
		   [FirstName] AS [First Name]
		   ,[LastName] AS [Last Name]
      FROM [Employees] AS e
	  JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
	  JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
     WHERE t.[Name] = @town
GO

EXEC usp_GetEmployeesFromTown 'Sofia'