USE [master]
GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Softuni')
DROP DATABASE [Softuni]
GO

