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
[AccountNumber] NVARCHAR(20) NOT NULL,
[FirstName] NVARCHAR(200) NOT NULL,
[LastName] NVARCHAR(200) NOT NULL,
[PhoneNumber] NVARCHAR(20) NOT NULL,
[EmergencyName] NVARCHAR(200) NOT NULL,
[EmergencyNumber] NVARCHAR(20) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers] ([AccountNumber], [FirstName], [LastName], [PhoneNumber], 
[EmergencyName], [EmergencyNumber]) VALUES 
('12345678', 'Ivan', 'Taina', '0898966543', 'Gosho', '9999999999'), 
('87654321', 'Pesho', 'Taina', '0898966543', 'Gosho', '9999999999'), 
('99999999', 'Goshko', 'Taina', '0898966543', 'Gosho', '9999999999')

CREATE TABLE [RoomStatus]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[RoomStatus] NVARCHAR(100) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomStatus] ([RoomStatus]) VALUES 
('good'), 
('bad'), 
('horror')

CREATE TABLE [RoomTypes]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[RoomType] NVARCHAR(100) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [RoomTypes] ([RoomType]) VALUES 
('large'), 
('medium'), 
('small')

CREATE TABLE [BedTypes]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[BedType] NVARCHAR(100) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [BedTypes] ([BedType]) VALUES 
('king'), 
('queen'), 
('small')

CREATE TABLE [Rooms]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[RoomNumber] NVARCHAR(20) NOT NULL,
[RoomType] BIGINT FOREIGN KEY REFERENCES [RoomTypes](Id) NOT NULL,
[BedType] BIGINT FOREIGN KEY REFERENCES [BedTypes](Id) NOT NULL,
[Rate] DECIMAL(5, 2) NOT NULL,
[RoomStatus] BIGINT FOREIGN KEY REFERENCES [RoomStatus](Id) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Rooms] ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus]) VALUES 
('23', 1, 1, 1.20, 2), 
('24', 2, 2, 1.20, 2), 
('25', 3, 3, 1.30, 2)

CREATE TABLE [Payments]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[EmployeeId] BIGINT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
[PaymentDate] DATETIME2 NOT NULL,
[AccountNumber] NVARCHAR(20) NOT NULL,
[FirstDateOccupied] DATE NOT NULL,
[LastDateOccupied] DATE NOT NULL,
[TotalDays] INT NOT NULL,
[AmountCharged] DECIMAL(5, 2) NOT NULL,
[TaxRate] DECIMAL(5, 2) NOT NULL,
[TaxAmount] DECIMAL(5, 2) NOT NULL,
[PaymentTotal] DECIMAL(5, 2) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Payments] ([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied],
[LastDateOccupied], [TotalDays], [AmountCharged], [TaxRate], [TaxAmount], [PaymentTotal]) VALUES 
(1, '01-02-2021', '33345', '03-03-2021', '05-03-2021', 2, 2.34, 0.20, 5, 2), 
(2, '01-02-2021', '33346', '03-03-2021', '05-03-2021', 2, 2.34, 0.20, 5, 2), 
(3, '01-02-2021', '33347', '03-03-2021', '05-03-2021', 2, 2.34, 0.20, 5, 2)

CREATE TABLE [Occupancies]
(
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[EmployeeId] BIGINT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
[DateOccupied] DATE NOT NULL,
[AccountNumber] NVARCHAR(20) NOT NULL,
[RoomNumber] NVARCHAR(20) NOT NULL,
[RateApplied] DECIMAL(5, 2) NOT NULL,
[PhoneCharge] DECIMAL(5, 2),
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Occupancies] ([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied]) VALUES 
(1, '01-01-2021', '444', '24', 2.2), 
(2, '01-01-2021', '445', '24', 2.2), 
(3, '01-01-2021', '446', '24', 2.2)