CREATE DATABASE CigarShop

---------------------------- 01. DDL

CREATE TABLE Brands
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,BrandName VARCHAR(30) UNIQUE NOT NULL
	,BrandDescription VARCHAR(MAX)
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,TasteType VARCHAR(20) NOT NULL
	,TasteStrength VARCHAR(15) NOT NULL
	,ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,Town VARCHAR(30) NOT NULL
	,Country NVARCHAR(30) NOT NULL
	,Streat NVARCHAR(100) NOT NULL
	,ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,FirstName  NVARCHAR(30) NOT NULL
	,LastName  NVARCHAR(30) NOT NULL
	,Email  NVARCHAR(50) NOT NULL
	,AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,Length INT NOT NULL
	,CHECK(Length BETWEEN 10 AND 25)
	,RingRange DECIMAL(15, 4) NOT NULL
	,CHECK(RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,CigarName VARCHAR(80) NOT NULL
	,BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(Id)
	,TastId INT NOT NULL FOREIGN KEY REFERENCES Tastes(Id)
	,SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id)
	,PriceForSingleCigar DECIMAL(15, 2) NOT NULL
	,ImageURL NVARCHAR(100) NOT NULL

)

CREATE TABLE ClientsCigars
(
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id)
	,CigarId INT NOT NULL FOREIGN KEY REFERENCES Cigars(Id)
	,PRIMARY KEY (ClientId, CigarId)
)

---------------------------- 02. Insert


INSERT INTO Addresses (Town, Country, Streat, ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', N'1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

---------------------------- 03. Update id 1

UPDATE Cigars
   SET PriceForSingleCigar *= 1.20
 WHERE TastId = 1

UPDATE Brands
   SET BrandDescription = 'New description'
 WHERE BrandDescription IS NULL


---------------------------- 04. Delete

DELETE FROM Clients WHERE AddressId IN (SELECT Id FROM Addresses WHERE Country LIKE 'C%')
DELETE FROM Addresses WHERE Country IN (SELECT Country FROM Addresses WHERE Country LIKE 'C%')

---------------------------- 05.

SELECT CigarName, PriceForSingleCigar, ImageURL FROM Cigars ORDER BY PriceForSingleCigar, CigarName

---------------------------- 06.

SELECT c.Id
       ,c.CigarName
	   ,c.PriceForSingleCigar
	   ,t.TasteType
	   ,t.TasteStrength
  FROM Cigars AS c
  JOIN Tastes AS t ON c.TastId = t.Id
 WHERE TasteType = 'Earthy' OR TasteType = 'Woody'
 ORDER BY c.PriceForSingleCigar DESC

---------------------------- 07.

SELECT c.Id
       ,CONCAT(c.FirstName, ' ', c.LastName) AS ClientName
	   ,c.Email
  FROM Clients AS c
  LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
  LEFT JOIN Cigars AS cg ON cc.CigarId = cg.Id
 WHERE cg.Id IS NULL
 ORDER BY ClientName

---------------------------- 08.

SELECT TOP(5) c.CigarName
       ,c.PriceForSingleCigar
	   ,c.ImageURL
  FROM Cigars AS c
  LEFT JOIN Sizes AS s ON c.SizeId = s.Id
 WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
 ORDER BY c.CigarName, c.PriceForSingleCigar DESC

SELECT *
  FROM Cigars AS c
  LEFT JOIN Sizes AS s ON c.SizeId = s.Id
 WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
 ORDER BY c.CigarName, c.PriceForSingleCigar DESC

---------------------------- 09.

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName
       ,a.Country
	   ,a.ZIP
	   ,CONCAT('$', CAST(MAX(cg.PriceForSingleCigar) AS VARCHAR)) AS CigarPrice
  FROM Clients AS c
  LEFT JOIN Addresses AS a ON c.AddressId = a.Id
  LEFT JOIN ClientsCigars as cc ON c.Id = cc.ClientId
  LEFT JOIN Cigars As cg ON cc.CigarId = cg.Id
 WHERE a.ZIP NOT LIKE '%[^0-9]%'
 GROUP BY c.FirstName, c.LastName,a.Country,a.ZIP
 ORDER BY FullName

---------------------------- 10.

SELECT c.LastName
       ,AVG(s.Length) AS CiagrLength
	   ,CEILING(AVG(s.RingRange)) AS CiagrRingRange
  FROM Clients AS c
  LEFT JOIN ClientsCigars as cc ON c.Id = cc.ClientId
  LEFT JOIN Cigars AS cg ON cc.CigarId = cg.Id
  LEFT JOIN Sizes AS s ON cg.SizeId = s.Id
 WHERE cg.Id IS NOT NULL
 GROUP BY c.LastName
 ORDER BY CiagrLength DESC

---------------------------- 11.

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
BEGIN
	RETURN (SELECT COUNT(cg.Id)
      FROM Clients AS c
      LEFT JOIN ClientsCigars as cc ON c.Id = cc.ClientId
      LEFT JOIN Cigars AS cg ON cc.CigarId = cg.Id
     WHERE c.FirstName = @name)
END

SELECT dbo.udf_ClientWithCigars('Betty')

---------------------------- 12.

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
	SELECT c.CigarName
		   ,CONCAT('$',c.PriceForSingleCigar) AS Price
		   ,t.TasteType
		   ,b.BrandName
		   ,CONCAT(s.[Length], ' cm') AS CigarLength
		   ,CONCAT(s.RingRange, ' cm') AS CigarRingRange
	  FROM Cigars AS c
	  JOIN Tastes AS t ON c.TastId = t.Id
	  LEFT JOIN Brands AS b ON c.BrandId = b.Id
	  LEFT JOIN Sizes AS s ON c.SizeId = s.Id
	 WHERE t.TasteType = @taste
	 ORDER BY CigarLength, CigarRingRange DESC

EXEC usp_SearchByTaste 'Woody'
---------------------------- SELECTS
