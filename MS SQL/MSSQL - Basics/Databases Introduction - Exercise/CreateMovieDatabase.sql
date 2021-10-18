CREATE TABLE [Directors]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[DirectorName] NVARCHAR(30) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors] ([DirectorName]) VALUES 
('Kevin'), 
('Bob'), 
('Stewy'),
('Pesho'),
('Pena')

CREATE TABLE [Genres]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[GenreName] NVARCHAR(30) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Genres] ([GenreName]) VALUES 
('Horror'), 
('Fantasy'), 
('Drama'),
('SCI-FI'),
('Action')

CREATE TABLE [Categories]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[CategoryName] NVARCHAR(30) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Categories] ([CategoryName]) VALUES 
('BGMovies'), 
('Oscars'), 
('Stupid'),
('Not Bad'),
('Cool')

CREATE TABLE [Movies]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Title] NVARCHAR(200) NOT NULL,
[DirectorId] BIGINT FOREIGN KEY REFERENCES [Directors](Id),
[CopyrightYear] INT,
[Length] NVARCHAR(15),
[GenreId] BIGINT FOREIGN KEY REFERENCES [Genres](Id),
[CategoryId] BIGINT FOREIGN KEY REFERENCES [Categories](Id),
[Rating] TINYINT,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating]) VALUES 
('Die Hard', 1, 1988, '2.33.44', 5, 3, 10), 
('Superman', 2, 2015, '2.00.00', 4, 2, 9), 
('Family Guy', 3, 2000, '1.44.50', 3, 1, 5),
('Rick and Morty', 4, 2016, '1.33.48', 2, 5, 8),
('Star Trek', 5, 2009, '2.00.00', 1, 4, 10)