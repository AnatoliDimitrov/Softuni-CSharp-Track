CREATE DATABASE TripService

--------------------------------- TASK 01. DDL

CREATE TABLE Cities
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,[Name] NVARCHAR(20) NOT NULL
	,CountryCode CHAR (2)
	,CHECK(LEN(CountryCode) = 2)
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
	,CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id)
	,EmployeeCount INT NOT NULL
	,BaseRate DECIMAL(15, 2)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,FirstName NVARCHAR(50) NOT NULL
	,MiddleName NVARCHAR(20)
	,LastName NVARCHAR(50) NOT NULL
	,CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id)
	,BirthDate DATE NOT NULL
	,Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,Price DECIMAL(15, 2) NOT NULL
	,[Type] NVARCHAR(20) NOT NULL
	,Beds INT NOT NULL
	,HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
	,BookDate DATE NOT NULL
	,ArrivalDate DATE NOT NULL
	,ReturnDate DATE NOT NULL
	,CancelDate DATE
	,CHECK(BookDate < ArrivalDate)
	,CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id)
	,TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id)
	,Luggage INT NOT NULL
	,CHECK(Luggage >= 0)
	,PRIMARY KEY (AccountId, TripId)
)

--------------------------------- TASK 02. Insert

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--------------------------------- TASK 03. Update

UPDATE Rooms
   SET Price *= 1.14
 WHERE HotelId IN (5, 7, 9)

--------------------------------- TASK 04. Delete

DELETE FROM AccountsTrips
 WHERE AccountId = 47
 
--------------------------------- TASK 05. EEE-Mails

SELECT a.FirstName
       ,a.LastName
	   , CONVERT(varchar, a.BirthDate, 110) AS BirthDate
	   ,c.[Name] AS Hometown
	   ,a.Email
  FROM Accounts AS a
  LEFT JOIN Cities AS c ON a.CityId = c.Id
 WHERE Email LIKE 'e%'
 ORDER BY c.[Name]

--------------------------------- TASK 06. City Statistics

SELECT c.[Name]
       ,COUNT(h.Id) AS Hotels
  FROM Cities AS c
  JOIN Hotels AS h ON c.Id = h.CityId
 GROUP BY c.[Name]
 ORDER BY Hotels DESC, c.[Name]

--------------------------------- TASK 07. Longest and Shortest Trips

SELECT a.Id
       ,CONCAT(a.FirstName, ' ', a.LastName) AS FullName
	   ,f.LongestTrip
	   ,f.ShortestTrip
  FROM
		(SELECT a.Id
			   ,MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip
			   ,MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
		  FROM Accounts AS a
		  JOIN AccountsTrips AS ac ON a.Id = ac.AccountId
		  JOIN Trips AS t on ac.TripId = t.Id
		 WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
		 GROUP BY a.Id) AS F
  JOIN Accounts AS a ON f.Id = a.Id
 ORDER BY f.LongestTrip DESC, f.ShortestTrip

--------------------------------- TASK 08. Metropolis

SELECT TOP (10) f.Id
       ,c.[Name] AS City
	   ,c.CountryCode AS Country
	   ,f.Accounts
  FROM 
		(SELECT c.Id
			   ,COUNT(a.Id) AS Accounts
		  FROM Cities AS c
		  JOIN Accounts AS a ON c.Id = a.CityId
		 GROUP BY c.Id) AS f
  JOIN Cities AS c ON c.Id = f.Id
 ORDER BY f.Accounts DESC

--------------------------------- TASK 09. Romantic Getaways

SELECT a.Id
       ,a.Email
	   ,c.[Name] AS City
	   ,COUNT(a.Id) AS Trips
  FROM Accounts AS a
  JOIN Cities AS c ON a.CityId = c.Id
  JOIN AccountsTrips AS ac ON a.Id = ac.AccountId
  JOIN Trips AS t ON ac.TripId = t.Id
  JOIN Rooms AS r ON t.RoomId = r.Id
  JOIN Hotels AS h ON r.HotelId = h.Id
 WHERE a.CityId = h.CityId
 GROUP BY a.Id, a.Email, c.[Name]
 ORDER BY Trips DESC, a.Id

--------------------------------- TASK 10. GDPR Violation

SELECT t.Id
       ,CASE WHEN a.MiddleName IS NULL THEN CONCAT(a.FirstName, ' ', a.LastName) ELSE CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) END AS [Full Name]
	   ,(SELECT [Name] FROM Cities WHERE Id = a.CityId) AS [From]
	   ,(SELECT [Name] FROM Cities WHERE Id = h.CityId) AS [To]
	   , CASE WHEN t.CancelDate IS NOT NULL THEN 'Canceled' ELSE CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS VARCHAR) + ' days' END AS Duration
  FROM Trips AS t
   JOIN AccountsTrips AS ac ON t.Id = ac.TripId
  LEFT JOIN Accounts AS a ON ac.AccountId = a.Id
  LEFT JOIN Rooms AS r ON t.RoomId = r.Id
  LEFT JOIN Hotels As h ON r.HotelId = h.Id
 ORDER BY [Full Name], t.Id

--------------------------------- TASK 11. Available Room

ALTER FUNCTION udf_GetAvailableRoom(@hotelId INT, @date DATE, @people INT)
RETURNS VARCHAR(300)
BEGIN 

	DECLARE @roomID INT = (SELECT TOP(1) Id 
	                                    FROM 
														(SELECT r.Id
																,r.Price
															FROM Rooms AS r
															JOIN Hotels AS h ON r.HotelId = h.Id
															JOIN Trips AS t On r.Id = t.RoomId
														WHERE h.Id = @hotelId AND (@date < t.ArrivalDate OR @date > t.ReturnDate) AND t.CancelDate IS NULL AND r.Beds >= @people)  AS f
										WHERE Price = (
									   SELECT MAX(Price) FROM(SELECT r.Price
										 FROM Rooms AS r
										 JOIN Hotels AS h ON r.HotelId = h.Id
										 JOIN Trips AS t On r.Id = t.RoomId
										WHERE h.Id = @hotelId AND (@date < t.ArrivalDate OR @date > t.ReturnDate) AND t.CancelDate IS NULL AND r.Beds >= @people
										GROUP BY r.Price) AS s))

	IF @roomId IS NULL RETURN 'No rooms available'

	DECLARE @counter INT = (SELECT COUNT(r.Id)
										 FROM Rooms AS r
										 JOIN Hotels AS h ON r.HotelId = h.Id
										 JOIN Trips AS t On r.Id = t.RoomId
										WHERE h.Id = @hotelId)

	WHILE (@counter >= 1)
	BEGIN
		 DECLARE @ad DATE = (SELECT ArrivalDate FROM (SELECT t.ArrivalDate, t.ReturnDate
		         ,RANK()OVER(ORDER BY t.id) AS ran
			FROM Rooms AS r
			JOIN Hotels AS h ON r.HotelId = h.Id
			JOIN Trips AS t On r.Id = t.RoomId
		WHERE h.Id = @hotelId)AS F
		WHERE ran = @counter)

		DECLARE @rd DATE = (SELECT ReturnDate FROM (SELECT t.ArrivalDate, t.ReturnDate
		         ,RANK()OVER(ORDER BY t.id) AS ran
			FROM Rooms AS r
			JOIN Hotels AS h ON r.HotelId = h.Id
			JOIN Trips AS t On r.Id = t.RoomId
		WHERE h.Id = @hotelId)AS F
		WHERE ran = @counter)
		SET @counter -= 1

		IF @date >= @ad AND @date <= @rd RETURN 'No rooms available'
	END
	
	DECLARE @roomTotalPrice DECIMAL(18, 2) = ((SELECT BaseRate FROM Hotels WHERE Id = @hotelId) + 
	                                          (SELECT Price FROM Rooms WHERE Id = @roomId))
											 * @people

	RETURN CONCAT('Room ', @roomId, ': ', (SELECT [Type] FROM Rooms where Id = @roomId), ' (', (SELECT Beds FROM Rooms where Id = @roomId), ' beds) - $', CAST(@roomTotalPrice AS VARCHAR))
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 4)

--------------------------------- TASK 12. Switch Room

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	SELECT * FROM Trips WHERE Id = @TripId
	SELECT * FROM Rooms WHERE Id = @TargetRoomId

GO

--------------------------------- SELECTS

SELECT * FROM Rooms
SELECT * FROM AccountsTrips
SELECT * FROM Accounts
SELECT * FROM Hotels
SELECT * FROM Cities
SELECT * FROM Trips

SELECT * FROM Trips WHERE Id = 10
SELECT * FROM Trips WHERE RoomId = 11
SELECT * FROM Rooms WHERE id = 11
SELECT * FROM Rooms WHERE id = 10