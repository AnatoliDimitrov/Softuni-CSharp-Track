USE [People]

GO

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Exams] 
(
	[ExamID] INT PRIMARY KEY NOT NULL IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT,
	[ExamID] INT,
	CONSTRAINT PK_StudentsExams
	PRIMARY KEY([StudentID], [ExamID]),
	CONSTRAINT FK_StudentsExams_Students
	FOREIGN KEY ([StudentID]) 
	REFERENCES [Students]([StudentID]),
	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY ([ExamID])
	REFERENCES [Exams]([ExamID])
)