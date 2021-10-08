CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @projectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

	IF @emloyeeId IS NULL 
	BEGIN
		ROLLBACK
		RETURN
	END
	IF @projectID IS NULL 
	BEGIN
		ROLLBACK
		RETURN
	END
	IF @projectsCount >= 3
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
	END

	INSERT INTO EmployeesProjects
	VALUES (@emloyeeId, @projectID)
COMMIT

EXEC usp_AssignProject 96, 111

SELECT * FROM EmployeesProjects WHERE EmployeeID = 96
