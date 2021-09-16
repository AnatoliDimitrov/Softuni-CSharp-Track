CREATE TABLE [Users]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX)
CHECK(DATALENGTH([ProfilePicture]) <= 900000),
[LastLoginTime] DATETIME2,
[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] ([Username], [Password], [LastLoginTime], [IsDeleted]) VALUES 
('Kevin', 'mpass', '06-08-1990', 0), 
('Bob', 'pass', '04-09-1988', 0), 
('Stewy', 'password', '02-01-1991', 0),
('Pesho', 'ggg', '02-01-1999', 0),
('Pena', 'somepass', '02-01-2000', 1)