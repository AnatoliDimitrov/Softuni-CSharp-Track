CREATE DATABASE Airport

-------------TASK 01. DDL

CREATE TABLE Planes
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
	,Seats INT NOT NULL
	,[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,DepartureTime DATETIME2
	,ArrivalTime DATETIME2
	,Origin NVARCHAR(50) NOT NULL
	,Destination NVARCHAR(50) NOT NULL
	,PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers
( 
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(30) NOT NULL
	,LastName NVARCHAR(30) NOT NULL
	,Age INT NOT NULL
	,Address NVARCHAR(30) NOT NULL
	,PassportId NVARCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,[Type] NVARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id)
	,PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

CREATE TABLE Tickets
(
	Id INT NOT NULL PRIMARY KEY IDENTITY
	,PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
	,FlightId INT NOT NULL FOREIGN KEY REFERENCES Flights(Id)
	,LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id)
	,Price DECIMAL(15, 2) NOT NULL
)

-------------TASK 02. Insert

INSERT INTO Planes
VALUES ('Airbus 336', 112, 5132),
		('Airbus 330', 432, 5325),
		('Boeing 369', 231, 2355),
		('Stelt 297', 254, 2143),
		('Boeing 338', 165, 5111),
		('Airbus 558', 387, 1342),
		('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes
VALUES ('Crossbody Bag'),
		('School Backpack'),
		('Shoulder Bag')

-------------TASK 03. Update

UPDATE Tickets
   SET Price *= 1.13
  FROM Flights AS f
  JOIN Tickets AS t ON f.Id = t.FlightId
 WHERE f.Destination = 'Carlsbad'

-------------TASK 04. Delete

DELETE FROM Tickets
WHERE FlightId = 30

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

-------------TASK 05. The "Tr" Planes

SELECT * FROM Planes
 WHERE Name LIKE '%tr%'
 ORDER BY Id, Name, Seats, Range

-------------TASK 06. Flight Profits

SELECT f.Id
       ,SUM(t.Price) AS Price
  FROM Flights AS f
  JOIN Tickets AS t ON f.Id = t.FlightId
 GROUP BY f.Id
 ORDER BY Price DESC, f.Id

-------------TASK 07. Passenger Trips

SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name]
       ,f.Origin
	   ,f.Destination
  FROM Passengers AS p
  JOIN Tickets AS t ON p.Id = t.PassengerId
  LEFT JOIN Flights AS f ON t.FlightId = f.Id
 ORDER BY [Full Name], f.Origin, f.Destination

-------------TASK 08. Non Adventures People

SELECT p.FirstName
       ,p.LastName
	   ,p.Age
  FROM Passengers AS p
  LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
  LEFT JOIN Flights AS f ON t.FlightId = f.Id
 WHERE t.Id IS NULL
 ORDER BY p.Age DESC, p.FirstName, p.LastName

-------------TASK 09. Full Info

SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name]
       ,pn.Name
	   ,CONCAT(f.Origin, ' - ', f.Destination) AS Trip
	   ,lt.Type AS [Luggage Type]
  FROM Passengers AS p
  JOIN Tickets AS t ON p.Id = t.PassengerId
  LEFT JOIN Flights AS f ON t.FlightId = f.Id
  LEFT JOIN Planes AS pn ON f.PlaneId = pn.Id
  LEFT JOIN Luggages AS l ON t.LuggageId = l.Id
  LEFT JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
 ORDER BY [Full Name], pn.Name, f.Origin, f.Destination, lt.Type

-------------TASK 10. PSP

SELECT * FROM
		(SELECT Name
			   ,pn.Seats
			   ,COUNT(p.Id) AS [Passengers Count]
		  FROM Planes AS pn
		  LEFT JOIN Flights AS f ON pn.Id = f.PlaneId
		  LEFT JOIN Tickets AS t ON f.Id = t.FlightId
		  LEFT JOIN Passengers AS p on t.PassengerId = p.Id
		  GROUP BY pn.Id, pn.Name, pn.Seats) AS f
 ORDER BY [Passengers Count] DESC, Name, Seats

-------------TASK 11. Vacation

CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
BEGIN
	DECLARE @flightId INT = (SELECT Id FROM Flights WHERE Origin = @origin AND Destination = @destination)

	IF (@flightId IS NULL)
	BEGIN
		RETURN 'Invalid flight!'
	END

	IF (@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!'
	END

	DECLARE @result VARCHAR(50) = CONCAT('Total price ', CAST((SELECT Price * @peopleCount FROM Flights AS f
   JOIN Tickets AS t ON f.Id = t.FlightId
   WHERE f.Origin = @origin AND f.Destination = @destination) AS VARCHAR))

   RETURN @result

END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

-------------TASK 11. Vacation

CREATE PROC usp_CancelFlights
AS
	UPDATE Flights
	   SET ArrivalTime = NULL, DepartureTime = NULL
	 WHERE ArrivalTime > DepartureTime
GO

EXEC usp_GetEmployeesSalaryAbove35000

-------------SELECTS

SELECT * FROM Flights AS f
  JOIN Tickets AS t ON f.Id = t.FlightId
 WHERE f.Destination = 'Ayn Halagim'

 SELECT * FROM Flights AS f
   JOIN Tickets AS t ON f.Id = t.FlightId
   WHERE f.Origin = 'Ilheus' AND f.Destination = 'San Lorenzo'

   SELECT * FROM Tickets
   ORDER BY FlightId



