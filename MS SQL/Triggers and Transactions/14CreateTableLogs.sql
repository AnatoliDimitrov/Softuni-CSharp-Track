CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY
	,AccountId INT NOT NULL
	,OldSum MONEY
	,NewSum MONEY
)

GO

CREATE TRIGGER tr_AccountsLogs ON Accounts FOR UPDATE
AS
	DECLARE @oldSum MONEY = (SELECT Balance FROM deleted)	
	DECLARE @newSum MONEY = (SELECT Balance FROM inserted)
	DECLARE @id INT = (SELECT Id FROM inserted)

	 INSERT INTO Logs
	 VALUES (@id, @oldSum, @newSum)
GO

SELECT * FROM Accounts

UPDATE Accounts
SET Balance += 100
WHERE Id = 1

SELECT * FROM Logs