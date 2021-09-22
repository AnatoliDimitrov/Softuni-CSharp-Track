USE master

GO

CREATE DATABASE [OnlineStoreDatabase]

USE [OnlineStoreDatabase]

CREATE TABLE [Cities]
(
	[CityID] INT PRIMARY KEY NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers]
(
	[CustomerID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE NOT NULL,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
)

CREATE TABLE [ItemTypes]
(
	[ItemTypeID] INT PRIMARY KEY NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items]
(
	[ItemID] INT PRIMARY KEY NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [Orders]
(
	[OrderID] INT PRIMARY KEY NOT NULL IDENTITY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [OrderItems]
(
	[OrderID] INT,
	[ItemID] INT,
	PRIMARY KEY([OrderID], [ItemID]),
	FOREIGN KEY ([OrderID]) REFERENCES [Customers]([CustomerID]),
	FOREIGN KEY ([ItemID]) REFERENCES [Items]([ItemID])
)
