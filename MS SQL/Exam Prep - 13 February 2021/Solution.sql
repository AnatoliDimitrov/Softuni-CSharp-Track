CREATE DATABASE Bitbucket

---------------------------TASK 01. DDL

CREATE TABLE Users
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,Username VARCHAR(30) NOT NULL
	,Password VARCHAR(30) NOT NULL
	,Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors 
(
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id)
	,ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
	,PRIMARY KEY(RepositoryId, ContributorId)

)

CREATE TABLE Issues 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,Title VARCHAR(255) NOT NULL
	,IssueStatus CHAR(6) NOT NULL
	,RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id)
	,AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,Message VARCHAR(255) NOT NULL
	,IssueId INT FOREIGN KEY REFERENCES Issues(Id)
	,RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id)
	,ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Files 
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,Name VARCHAR(100) NOT NULL
	,Size DECIMAL(10, 2) NOT NULL
	,ParentId INT FOREIGN KEY REFERENCES Files(Id)
	,CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)

---------------------------TASK 02. Insert

INSERT INTO Files
VALUES  ('Trade.idk', 2598.0, 1, 1),
		('menu.net', 9238.31, 2, 2),
		('Administrate.soshy', 1246.93, 3, 3),
		('Controller.php', 7353.15, 4, 4),
		('Find.java', 9957.86, 5, 5),
		('Controller.json', 14034.87, 3, 6),
		('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues
VALUES  ('Critical Problem with HomeController.cs file', 'open', 1, 4),
		('Typo fix in Judge.html', 'open', 4, 3),
		('Implement documentation for UsersService.cs', 'closed', 8, 2),
		('Unreachable code in Index.cs', 'open', 9, 8)

---------------------------TASK 03. Update

UPDATE Issues
   SET IssueStatus = 'Closed'
 WHERE Id = 6

---------------------------TASK 04. Delete ID 3

UPDATE Files
   SET ParentId = NULL
 WHERE ParentId IN (SELECT Id FROM Commits WHERE RepositoryId = 3)

DELETE FROM Files 
 WHERE CommitId IN (SELECT Id FROM Commits WHERE RepositoryId = 3)

DELETE FROM Commits WHERE RepositoryId = 3
DELETE FROM Issues WHERE RepositoryId = 3
DELETE FROM RepositoriesContributors WHERE RepositoryId = 3
DELETE FROM Repositories WHERE Name = 'Softuni-Teamwork'

---------------------------TASK 05. Commits

SELECT Id
       ,Message
	   ,RepositoryId
	   ,ContributorId
  FROM Commits
 ORDER BY Id, Message, RepositoryId, ContributorId

---------------------------TASK 06. Front-end

SELECT Id, Name, Size
  FROM Files
 WHERE Size > 1000 AND Name LIKE '%html%'
 ORDER BY Size DESC, Id, Name

---------------------------TASK 07. Issue Assignment

SELECT i.Id
	   ,CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
  FROM Issues AS i
  JOIN Users AS u ON i.AssigneeId = u.Id
 ORDER BY i.Id DESC, IssueAssignee

---------------------------TASK 08. Single Files

SELECT Id
       ,Name
	   ,CONCAT(Size, 'KB') AS Size
  FROM Files
 WHERE Id NOT IN (SELECT ISNULL(ParentId, 0) FROM Files)
 ORDER BY Id, Name, Size DESC

---------------------------TASK 09. Commits in Repositories

SELECT TOP(5) r.Id
       ,r.Name
	   ,COUNT(c.Id) AS Commits
  FROM Repositories AS r
  JOIN Commits AS c ON r.Id = c.RepositoryId
  LEFT JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
 GROUP BY r.Id, r.Name
 ORDER BY Commits DESC, r.Id, r.Name

---------------------------TASK 10. Average Size
SELECT * FROM
(SELECT Username
       ,ISNULL(AVG(Size), 0) AS Size
  FROM Commits AS c
  LEFT JOIN Files AS f ON c.Id = f.CommitId
  LEFT JOIN Users AS u ON c.ContributorId = u.Id
  GROUP BY Username)AS f
 WHERE Size > 0
 ORDER BY Size DESC, Username

---------------------------TASK 11. All User Commits

ALTER FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
BEGIN
	
	DECLARE @id INT = (SELECT Id FROM Users WHERE Username = @username)

	RETURN (SELECT COUNT(Id)
      FROM Commits WHERE ContributorId = @id)
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

---------------------------TASK 12. Search for Files

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(40))
AS
	SELECT Id
	       ,Name
		   ,CONCAT(CAST(Size AS VARCHAR(40)), 'KB') AS Size
      FROM Files
     WHERE Name LIKE '%.' + @fileExtension
GO

EXEC usp_SearchForFiles 'txt'

