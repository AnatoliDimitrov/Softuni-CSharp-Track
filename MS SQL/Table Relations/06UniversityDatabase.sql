USE master

GO

CREATE DATABASE [UniversityDatabase]

GO

USE [UniversityDatabase]

GO

CREATE TABLE [Majors]
(
	[MajorID] INT PRIMARY KEY NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE [Subjects]
(
	[SubjectID] INT PRIMARY KEY NOT NULL IDENTITY,
	[SubjectName] VARCHAR(50)
)

CREATE TABLE [Students]
(
	[StudentsID] INT PRIMARY KEY NOT NULL IDENTITY,
	[StudentNumber] VARCHAR(50) NOT NULL,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments]
(
	[PaymentID] INT PRIMARY KEY NOT NULL IDENTITY,
	[PaymentDate] DATETIME2 NOT NULL,
	[PaymentAmount] DECIMAL(10, 4),
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentsID])
)

CREATE TABLE [Agenda]
(
	[StudentID] INT,
	[SubjectID] INT,
	PRIMARY KEY([StudentID], [SubjectID]),
	FOREIGN KEY([StudentID]) REFERENCES [Students]([StudentsID]),
	FOREIGN KEY([SubjectID]) REFERENCES [Subjects]([SubjectID])
)