CREATE DATABASE [Service]


CREATE TABLE [Status]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Label] NVARCHAR(30) NOT NULL
)

CREATE TABLE Users
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,Username NVARCHAR(30) NOT NULL UNIQUE
	,[Password] NVARCHAR(50) NOT NULL
	,[Name] NVARCHAR(50)
	,Birthdate DATETIME2
	,Age INT NOT NULL
	,CHECK (Age >= 14 AND Age <= 110)
	,Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Categories
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
	,DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Employees
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(25)
	,LastName NVARCHAR(25)
	,Birthdate DATETIME2
	,Age INT NOT NULL 
	,CHECK (Age >= 18 AND Age <= 110)
	,DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) 
)

CREATE TABLE Reports
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id) 
	,StatusId INT NOT NULL FOREIGN KEY REFERENCES [Status](Id) 
	,OpenDate DATETIME2 NOT NULL
	,CloseDate DATETIME2
	,[Description] NVARCHAR(200) NOT NULL
	,UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id) 
	,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

------------TASK INSERT - 2

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES ('Marlo', 'O''Malley', '1958-9-21', 1),
		('Niki', 'Stanaghan', '1969-11-26', 4),
		('Ayrton', 'Senna', '1960-03-21', 9),
		('Ronnie', 'Peterson', '1944-02-14', 9),
		('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

------------TASK UPDATE - 3

UPDATE Reports
   SET CloseDate = GETDATE()
 WHERE CloseDate IS NULL

------------TASK DELETE - 4

DELETE 
  FROM Reports
 WHERE StatusId = 4

------------TASK Unassigned Reports - 5

SELECT [Description]
	   ,FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
  FROM
		(SELECT TOP (1000) [Description]
			   ,OpenDate
		  FROM Reports
		 WHERE EmployeeId IS NULL
		 ORDER BY OpenDate, [Description])AS f

 ------------TASK Reports & Categories - 6

SELECT r.[Description]
       ,c.[Name] AS CategoryName
  FROM Reports AS r
  LEFT JOIN Categories AS c ON r.CategoryId = c.Id
 ORDER BY r.[Description], c.[Name] 
 
------------TASK Most Reported Category - 7

SELECT TOP (5) c.Name AS CategoryName
	   ,COUNT(CategoryId) AS ReportsNumber
  FROM Reports AS r
  LEFT JOIN Categories AS c ON r.CategoryId = c.Id
  GROUP BY CategoryId, c.Name
  ORDER BY ReportsNumber DESC, c.Name

 ------------TASK 8. Birthday Report

 SELECT u.Username
        ,c.[Name] AS CategoryName
   FROM Reports AS r
   LEFT JOIN Users AS u ON r.UserId = u.Id
   LEFT JOIN Categories AS c ON r.CategoryId = c.Id
  WHERE FORMAT(r.OpenDate, 'dd-MM') = FORMAT(u.Birthdate, 'dd-MM')
  ORDER BY u.Username, c.[Name]

------------TASK 9.	Users per Employee

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName
    ,COUNT(u.Id) AS UsersCount
  FROM Employees AS e
  LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
  LEFT JOIN Users AS u ON r.UserId = u.Id
 GROUP BY e.Id, CONCAT(e.FirstName, ' ', e.LastName)
 ORDER BY UsersCount DESC, FullName

------------TASK 10. Full Info

SELECT CASE WHEN e.FirstName IS NULL THEN 'None' ELSE CONCAT(e.FirstName, ' ', e.LastName) END AS Employee
       ,CASE WHEN e.DepartmentId IS NULL THEN 'None' ELSE d.[Name] END AS Department
	   ,CASE WHEN r.CategoryId IS NULL THEN 'None' ELSE c.[Name] END AS Category
	   ,CASE WHEN r.[Description] IS NULL THEN 'None' ELSE r.[Description] END AS [Description]
	   ,FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate
	   ,CASE WHEN r.StatusId IS NULL THEN 'None' ELSE s.[Label] END AS [Status]
	   ,u.[Name] AS [User]
  FROM Reports AS r
  LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
  LEFT JOIN Categories AS c ON r.CategoryId = c.Id
  LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
  LEFT JOIN [Status] AS s ON r.StatusId = s.Id
  LEFT JOIN Users AS u ON r.UserId = u.Id
 ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, r.[Description], r.OpenDate, [Status], [User]

------------TASK 11. Hours to Complete

 CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME2, @EndDate DATETIME2) 
RETURNS INT
  BEGIN
		RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
    END

SELECT CASE WHEN dbo.udf_HoursToComplete(OpenDate, CloseDate) IS NULL THEN 0 ELSE dbo.udf_HoursToComplete(OpenDate, CloseDate) END AS TotalHours
   FROM Reports

------------TASK 11. Hours to Complete
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @emplyeeDepartment INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)
	DECLARE @reportCategory INT = (SELECT c.DepartmentId
								     FROM Reports AS r
								     LEFT JOIN Categories AS c ON r.CategoryId = c.Id
								    WHERE r.Id = @ReportId
									)

	IF @emplyeeDepartment <> @reportCategory
	BEGIN
	RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
	RETURN
	END

	UPDATE Reports
	   SET EmployeeId = @EmployeeId
	 WHERE Id = @ReportId

GO

EXEC usp_AssignEmployeeToReport 17, 2

SELECT * FROM Employees WHERE Id = 17
SELECT c.DepartmentId
  FROM Reports AS r
  LEFT JOIN Categories AS c ON r.CategoryId = c.Id
  WHERE r.Id = 2