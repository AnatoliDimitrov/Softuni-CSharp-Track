CREATE PROC usp_WithdrawMoney(@accountId INT, @moneyAmount DECIMAL(18, 4))
AS
BEGIN TRANSACTION
	IF @accountId IS NULL 
	BEGIN
		ROLLBACK
		RETURN
	END
	IF @moneyAmount IS NULL 
	BEGIN
		ROLLBACK
		RETURN
	END

	UPDATE Accounts
	SET Balance -= @moneyAmount 
	WHERE Id = @accountId 
COMMIT

EXEC usp_WithdrawMoney 1, 100