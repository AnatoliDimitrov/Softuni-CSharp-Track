CREATE DATABASE WMS

---------------------TASK 01. DDL

CREATE TABLE Vendors
(
	VendorId INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL UNIQUE

)

CREATE TABLE Models
(
	ModelId INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL UNIQUE

)

CREATE TABLE Mechanics
(
	MechanicId INT NOT NULL PRIMARY KEY IDENTITY
	,FirstName VARCHAR(50) NOT NULL
	,LastName VARCHAR(50) NOT NULL
	,[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Clients
(
	ClientId INT NOT NULL PRIMARY KEY IDENTITY
	,FirstName VARCHAR(50) NOT NULL
	,LastName VARCHAR(50) NOT NULL
	,Phone VARCHAR(12) NOT NULL
	,CHECK(LEN(Phone) = 12)
)

CREATE TABLE Jobs
(
	JobId INT NOT NULL PRIMARY KEY IDENTITY
	,ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(ModelId)
	,[Status] VARCHAR(11) NOT NULL DEFAULT('Pending')
	,CHECK([Status] IN ('Pending', 'In Progress', 'Finished'))
	,ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientId)
	,MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId)
	,IssueDate DATE NOT NULL
	,FinishDate DATE

)

CREATE TABLE Orders
(
	OrderId INT NOT NULL PRIMARY KEY IDENTITY
	,JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId)
	,IssueDate DATE
	,Delivered BIT DEFAULT(0)
)

CREATE TABLE Parts
(
	PartId INT NOT NULL PRIMARY KEY IDENTITY
	,SerialNumber VARCHAR(50) NOT NULL UNIQUE
	,[Description] VARCHAR(255)
	,Price DECIMAL(6, 2) NOT NULL
	,CHECK(Price > 0 AND Price <= 9999.99)
	,VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId)
	,StockQty INT NOT NULL DEFAULT(0)
	,CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId)
	,PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId)
	,Quantity INT NOT NULL DEFAULT(1)
	,CHECK(Quantity > 0)
	,PRIMARY KEY (OrderId, PartId)

)

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId)
	,PartId	INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId)
	,Quantity INT NOT NULL DEFAULT(1)
	,CHECK(Quantity > 0)
	,PRIMARY KEY (JobId, PartId)
)

---------------------TASK 02. Insert

INSERT INTO Clients (FirstName, LastName, Phone)
 VALUES ('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId)
 VALUES ('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

---------------------TASK 03. Update

UPDATE Jobs
   SET MechanicId = 3
 WHERE [Status] = 'Pending'

UPDATE Jobs
   SET [Status] = 'In Progress'
 WHERE [Status] = 'Pending'

---------------------TASK 04. Delete

 DELETE FROM OrderParts
 WHERE OrderId = 19

DELETE FROM Orders
 WHERE OrderId = 19

---------------------TASK 05. Mechanic Assignments

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic
	   ,j.[Status]
	   ,j.IssueDate
  FROM Mechanics AS m
  LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
 ORDER BY m.MechanicId, j.IssueDate, j.JobId

---------------------TASK 06. Current Clients

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client
       ,DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going]
	   ,j.[Status]
  FROM Clients AS c
  LEFT JOIN Jobs AS j ON c.ClientId = j.ClientId
  WHERE j.[Status] <> 'Finished'
  ORDER BY [Days going] DESC, c.ClientId

---------------------TASK 07. Mechanic Performance

SELECT Mechanic
       ,AVG([Days going]) AS [Days going]
  FROM
		(SELECT m.MechanicId
			   ,CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic
			   ,DATEDIFF(DAY, j.IssueDate, j.FinishDate) AS [Days going]
		  FROM Mechanics AS m
		  LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
		 WHERE j.[Status] = 'Finished') AS f
 GROUP BY MechanicId, Mechanic
 ORDER BY MechanicId

---------------------TASK 08. Available Mechanics

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Available
  FROM Mechanics AS m
  LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
 WHERE m.MechanicId NOT IN (SELECT MechanicId
                              FROM Jobs
                             WHERE [Status] = 'In Progress')
 GROUP BY m.MechanicId, m.FirstName, m.LastName

---------------------TASK 09. Past Expenses

SELECT j.JobId
       ,SUM(p.Price * pn.Quantity) AS Total
  FROM Jobs AS j
  LEFT JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
  LEFT JOIN Parts AS p ON pn.PartId = p.PartId
 WHERE j.[Status] = 'Finished'
 GROUP BY j.JobId
 ORDER BY Total DESC, j.JobId

---------------------TASK 10. Missing Parts

SELECT *
  FROM
		(SELECT f.PartId
			   ,f.Description
			   ,f.Required
			   ,CASE WHEN s.Quantity IS NULL THEN f.StockQty ELSE f.StockQty + s.Quantity END AS [In Stock]
			   ,CASE WHEN s.Quantity IS NULL THEN 0 ELSE s.Quantity END AS [Ordered]
		  FROM
				(SELECT  p.PartId
						, p.[Description]
						, SUM(pn.Quantity) AS [Required]
						, p.StockQty
				  FROM Parts AS p
				  LEFT JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
				  LEFT JOIN Jobs AS j ON pn.JobId = j.JobId
				 WHERE j.Status <> 'Finished'
				 GROUP BY p.PartId, p.[Description], p.StockQty) AS f
				  LEFT JOIN (SELECT p.PartId, op.Quantity
							FROM Parts AS p
							LEFT JOIN OrderParts AS op ON p.PartId = op.PartId
							LEFT JOIN Orders AS o ON op.OrderId = o.OrderId
							WHERE Delivered = 0) AS s ON f.PartId = s.PartId) AS t
 WHERE [Required] > [In Stock]

---------------------TASK 11. Place Order

CREATE PROC usp_PlaceOrder(@jobId INT, @serialNumber VARCHAR(50),@quantity INT)
--------------Judge is down so the PROC is not Tested
AS
BEGIN TRANSACTION

	IF (@quantity <= 0) 
	BEGIN
		ROLLBACK;
		THROW 50012, 'Part quantity must be more than zero!', 1;
		RETURN
	END
   
	IF ((SELECT [Status] FROM Jobs WHERE JobId = @jobId) = 'Finished')
	BEGIN
		ROLLBACK;
		THROW 50011, 'This job is not active!', 1;
		RETURN;
	END

	IF (SELECT JobId FROM Jobs WHERE JobId = @jobId) IS NULL
	BEGIN
		ROLLBACK;
		THROW 50013, 'Job not found!', 1;
		RETURN
	END

	IF (SELECT SerialNumber FROM Parts WHERE SerialNumber = @serialNumber) IS NULL
	BEGIN
		ROLLBACK;
		THROW 50014, 'Part not found!', 1;
		RETURN
	END

	IF ((SELECT [Status] FROM Jobs WHERE JobId = @jobId) = 'Finished')
	BEGIN
		ROLLBACK;
		THROW 50011, 'This job is not active!', 1;
		RETURN;
	END
	
	DECLARE @orderExist INT = (SELECT o.OrderId FROM Orders AS o
		  JOIN OrderParts AS op ON o.OrderId = op.OrderId
		  JOIN Parts AS p ON op.PartId = p.PartId
		 WHERE p.SerialNumber = @serialNumber AND o.JobId = @jobId AND o.IssueDate IS NULL)

	DECLARE @partId INT = (SELECT PartId FROM Parts
		 WHERE SerialNumber = @serialNumber)

	IF (@orderExist >= 1)
	BEGIN
		UPDATE OrderParts
		   SET Quantity += @quantity
		 WHERE PartId = @partId AND OrderId = @orderExist
	END

	DECLARE @lastOrderId INT = (SELECT MAX(OrderId ) FROM Orders)

	IF (@orderExist IS NULL)
	BEGIN
		INSERT INTO Orders VALUES (@jobId, NULL, 0)
		INSERT INTO OrderParts VALUES (@lastOrderId, @partId, @quantity)
	END
COMMIT

SELECT * FROM Orders AS o
		  JOIN OrderParts AS op ON o.OrderId = op.OrderId
		  JOIN Parts AS p ON op.PartId = p.PartId
		  JOIN Jobs AS j ON o.JobId = j.JobId
		 --WHERE p.SerialNumber = 'ZeroQuantity' AND o.JobId = 1 AND op.Quantity = 0 AND o.IssueDate IS NULL

EXEC usp_PlaceOrder 45, 80040, 4

---------------------TASK 12. Cost of Order

CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(10, 2)
BEGIN
	DECLARE @id INT = (SELECT JobId FROM Jobs WHERE JobId = @jobId)

	IF (@id IS NULL)
	BEGIN
		RETURN 0
	END
	
	RETURN (SELECT SUM(p.Price)
			  FROM Jobs AS j
			  LEFT JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
			  LEFT JOIN Parts AS p ON pn.PartId = p.PartId
			 WHERE j.JobId = @jobId
			 GROUP BY j.JobId)
END

SELECT dbo.udf_GetCost(1)