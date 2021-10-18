CREATE TABLE [Categories]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[CategoryName] NVARCHAR(30) NOT NULL,
[DailyRate] DECIMAL(5, 2),
[WeeklyRate] DECIMAL(5, 2),
[MonthlyRate] DECIMAL(5, 2),
[WeekendRate] DECIMAL(5, 2)
)

INSERT INTO [Categories] ([CategoryName]) VALUES 
('Working Cars'), 
('Family Cars'), 
('City Cars')

CREATE TABLE [Cars]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[PlateNumber] NVARCHAR(10) NOT NULL,
[Manufacturer] VARCHAR(50) NOT NULL,
[Model] VARCHAR(50) NOT NULL,
[CarYear] INT,
[CategoryId] BIGINT FOREIGN KEY REFERENCES [Categories](Id),
[Doors] TINYINT,
[Picture] VARBINARY(MAX) CHECK(DATALENGTH([Picture]) <= 2097152),
[Condition] NVARCHAR(300) NOT NULL,
[Available] BIT NOT NULL
)

INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [Condition], [Available] ) VALUES 
('СВ3456НК', 'Alfa Romeo', 'julia', 'Good', 1), 
('СВ3336НК', 'BMW', '750', 'Perfect', 0), 
('СВ1111НК', 'Mercedes', 'S500', 'bad', 1)

CREATE TABLE [Employees]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[FirstName] NVARCHAR(200) NOT NULL,
[LastName] NVARCHAR(200) NOT NULL,
[Title] NVARCHAR(200),
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName]) VALUES 
('Kevin', 'Bakon'), 
('Bob', 'Marly'), 
('Stewy', 'Nekoi si')

CREATE TABLE [Customers]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[DriverLicenceNumber] NVARCHAR(20) NOT NULL,
[FullName] NVARCHAR(200) NOT NULL,
[Address] NVARCHAR(300) NOT NULL,
[City] NVARCHAR(100) NOT NULL,
[ZIPCode] INT,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [Address], [City]) VALUES 
('12345678', 'Ivan', 'Taina', 'Sofia'), 
('87654321', 'Pesho', 'Taina', 'Sofia'), 
('99999999', 'Goshko', 'Taina', 'Sofia')

CREATE TABLE [RentalOrders]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[EmployeeId] BIGINT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
[CustomerId] BIGINT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL,
[CarId] BIGINT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL,
[TankLevel] TINYINT NOT NULL,
[KilometrageStart] INT NOT NULL,
[KilometrageEnd] INT NOT NULL,
[TotalKilometrage] INT NOT NULL,
[StartDate] DATE NOT NULL,
[EndDate] DATE NOT NULL,
[TotalDays] INT NOT NULL,
[RateApplied] DECIMAL(5, 2) NOT NULL,
[TaxRate] DECIMAL(5, 2),
[OrderStatus] NVARCHAR(100) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], 
[KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate],
[EndDate], [TotalDays], [RateApplied], [OrderStatus]) VALUES 
(1, 1, 3, 100, 1000, 2000, 1000, '01-01-2021', '03-01-2021', 2, 2.55, 'Proffit'), 
(2, 2, 2, 100, 1000, 2000, 1000, '01-01-2021', '03-01-2021', 2, 2.55, 'Proffit'), 
(3, 3, 1, 100, 1000, 2000, 1000, '01-01-2021', '03-01-2021', 2, 2.55, 'Proffit')