CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY
	,Recipient INT
	,[Subject] VARCHAR(MAX)
	,Body VARCHAR(MAX)
)

GO

CREATE TRIGGER tr_AccountsEmails ON Logs FOR INSERT
AS
	DECLARE @recipient INT = (SELECT AccountId FROM inserted)
	DECLARE @oldSum MONEY = (SELECT OldSum FROM inserted)	
	DECLARE @newSum MONEY = (SELECT NewSum FROM inserted)

	 INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	 VALUES (@recipient,
		     'Balance change for account: ' + CAST(@recipient AS VARCHAR),
			 'On ' + CONVERT(VARCHAR, GETDATE(), 0) + 
			 ' your balance was changed from ' 
			 + CAST(@oldSum AS VARCHAR) + 
			 ' to '
			 + CAST(@newSum AS VARCHAR) + 
			 '.'
			 )
GO

UPDATE Accounts
SET Balance -= 100
WHERE Id = 1

SELECT * FROM Logs
SELECT * FROM NotificationEmails