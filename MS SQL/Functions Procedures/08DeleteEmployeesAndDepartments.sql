CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
	DECLARE @IDS TABLE ([Id] INT)

	INSERT INTO @IDS SELECT [EmployeeID] FROM [Employees] WHERE [DepartmentID] = @departmentId
	
	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] 
	INT NULL

	UPDATE [Departments]
	   SET ManagerID = NULL
	 WHERE DepartmentID = @departmentId

	UPDATE [Employees]
	   SET ManagerID = NULL
	 WHERE ManagerID IN (SELECT [Id] FROM @IDS)

	DELETE FROM EmployeesProjects
     WHERE EmployeeID IN (SELECT [Id] FROM @IDS)
	 
	DELETE FROM [Employees]
	 WHERE [DepartmentID] = @departmentId
	 
    DELETE FROM [Departments]
	 WHERE [DepartmentID] = @departmentId

	SELECT COUNT(*) 
      FROM [Employees]
     WHERE [DepartmentID] = @departmentId
GO

EXEC usp_DeleteEmployeesFromDepartment 4

SELECT * 
  FROM [Employees]
 WHERE [DepartmentID] = 4

 SELECT *
   FROM [EmployeesProjects]

   DELETE FROM [EmployeesProjects] WHERE EmployeeID = 1