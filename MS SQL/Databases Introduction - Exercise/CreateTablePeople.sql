CREATE TABLE [People]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX)
CHECK(DATALENGTH([Picture]) <= 2097152),
[Height] DECIMAL(5,2),
[Weight] DECIMAL(5,2),
[Gender] CHAR(1) NOT NULL,
check([Gender] in ('M', 'F')),
[Birthdate] DATE NOT NULL,
[Biography] NVARCHAR(MAX)
)

INSERT INTO dbo.People ([Name], [Height], [Weight], [Gender], [Birthdate]) VALUES 
('Kevin', 1.84, 90, 'm', '06-08-1990'), 
('Bob', 1.84, 90, 'm', '04-09-1988'), 
('Stewy', 1.84, 85, 'm', '02-01-1991'),
('Pesho', 1.75, 84, 'm', '02-01-1999'),
('Pena', 1.74, 82, 'f', '02-01-2000')