CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	IF @senderId IS NULL 
	BEGIN
		ROLLBACK
		RETURN
	END
	IF @receiverId IS NULL 
	BEGIN
		ROLLBACK
		RETURN
	END
	IF @amount IS NULL 
	BEGIN
		ROLLBACK
		RETURN
	END

	UPDATE Accounts
	SET Balance -= @amount 
	WHERE Id = @senderId 

	UPDATE Accounts
	SET Balance += @amount 
	WHERE Id = @receiverId
COMMIT

EXEC usp_TransferMoney 2, 1, 100