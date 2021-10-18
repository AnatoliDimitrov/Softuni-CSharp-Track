CREATE DATABASE Bakery

---------------TASK 01. DDL

CREATE TABLE Products
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,[Name] NVARCHAR(25) UNIQUE
	,[Description] NVARCHAR(250)
	,Recipe NVARCHAR(MAX)
	,Price DECIMAL(15, 2)
	,CHECK(Price >= 0)
)

CREATE TABLE Countries
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,FirstName NVARCHAR(25)
	,LastName NVARCHAR(25)
	,Gender CHAR(1)
	,CHECK(Gender IN ('M', 'F'))
	,Age INT
	,PhoneNumber CHAR(10)
	,CHECK(LEN(PhoneNumber) = 10)
	,CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,[Description] NVARCHAR(255)
	,Rate DECIMAL(15, 2)
	,CHECK(Rate >= 0 AND Rate <= 10)
	,ProductId INT FOREIGN KEY REFERENCES Products(Id)
	,CustomerId INT FOREIGN KEY REFERENCES Customers(Id)

)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,[Name] NVARCHAR(25) UNIQUE
	,AddressText NVARCHAR(30)
	,Summary NVARCHAR(200)
	,CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,[Name] NVARCHAR(30)
	,[Description] NVARCHAR(200)
	,OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id)
	,DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id)
	,IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id)
	,PRIMARY KEY (ProductId, IngredientId)
)

---------------TASK 02. Insert

INSERT INTO Distributors ([Name], CountryId, AddressText, Summary)
VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

---------------TASK 03. Update

UPDATE Ingredients
   SET DistributorId = 35
 WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
   SET OriginCountryId = 14
 WHERE OriginCountryId = 8

---------------TASK 04. Delete

DELETE FROM Feedbacks WHERE CustomerId = 14 OR ProductId = 5

---------------TASK 05. Products By Price

SELECT [Name]
       ,Price
	   ,[Description]
  FROM Products
 ORDER BY Price DESC, [Name]

---------------TASK 06. Negative Feedback

SELECT f.ProductId
       ,f.Rate
	   ,f.[Description]
	   ,f.CustomerId
	   ,c.Age
	   ,c.Gender
  FROM Feedbacks AS f
  LEFT JOIN Customers AS c ON f.CustomerId = c.Id
 WHERE f.Rate < 5.0
 ORDER BY f.ProductId DESC, f.Rate

---------------TASK 07. Customers without Feedback

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
       ,c.PhoneNumber
	   ,c.Gender
  FROM Customers AS c
  LEFT JOIN Feedbacks As f ON c.Id = f.CustomerId
 WHERE f.Id IS NULL
 ORDER BY c.Id

---------------TASK 07. Customers without Feedback

SELECT c.FirstName
       ,c.Age
	   ,c.PhoneNumber
  FROM Customers AS c
  LEFT JOIN Countries AS cn ON c.CountryId = cn.Id
  WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') OR (c.PhoneNumber LIKE '%38'  AND cn.[Name] <> 'Greece')
  ORDER BY c.FirstName, c.Age DESC

---------------TASK 09. Middle Range Distributors

SELECT d.[Name] AS DistributorName
       ,i.[Name] AS IngredientName
	   ,p.[Name] AS ProductName
	   ,f.AvgRate AS AverageRate
  FROM (SELECT ProductId
               ,AVG(ISNULL(Rate, 0)) AS AvgRate
          FROM Products AS p
          LEFT JOIN Feedbacks AS f ON p.Id = f.ProductId
         GROUP BY ProductId) AS f
  JOIN Products AS p ON p.Id = f.ProductId
  JOIN ProductsIngredients AS pin ON p.Id = pin.ProductId
  LEFT JOIN Ingredients AS i ON pin.IngredientId = i.Id
  LEFT JOIN Distributors AS d ON i.DistributorId = d.Id
 WHERE f.AvgRate >= 5 AND f.AvgRate <= 8
 ORDER BY d.[Name], i.[Name], p.[Name]

---------------TASK 10. Country Representative
SELECT CountryName
       ,DisributorName
FROM
		(SELECT c.Name AS CountryName
			   ,d.Name AS DisributorName
			   ,DENSE_RANK() OVER (PARTITION BY c.Id ORDER BY f.IngredientsCount DESC) AS [Rank]
		  FROM
				(SELECT d.Id
					   ,COUNT(i.DistributorId) AS IngredientsCount
				  FROM Countries AS c
				  JOIN Distributors AS d ON c.Id = d.CountryId
				  LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
				 GROUP BY d.Id) AS f
		  LEFT JOIN Distributors AS d ON f.Id = d.Id
		  LEFT JOIN Countries as c ON d.CountryId = c.Id) AS s
 WHERE s.[Rank] = 1
 ORDER BY CountryName, DisributorName
  
---------------TASK 11. Customers With Countries

CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
       ,c.Age
	   ,c.Gender
	   ,cn.Name
  FROM Customers AS c
  LEFT JOIN Countries AS cn ON c.CountryId = cn.Id

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

---------------TASK 12. Delete Products

