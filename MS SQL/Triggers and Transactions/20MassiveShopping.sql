DECLARE @UGId INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)
DECLARE @cash DECIMAL(18, 2) = (SELECT Cash FROM UsersGames WHERE Id = @UGId)
DECLARE @price DECIMAL(18, 2) = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE
(MinLevel BETWEEN  11 AND 12))

IF @cash > = @price
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
		SET Cash -= @price WHERE Id = @UGId

		INSERT INTO UserGameItems
		SELECT Id, @UGId FROM Items WHERE MinLevel BETWEEN 11 AND 12

	COMMIT
END

SET @cash = (SELECT Cash FROM UsersGames WHERE Id = @UGId)
SET @price = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE
(MinLevel BETWEEN  19 AND 21))

IF @cash > = @price
BEGIN
	BEGIN TRANSACTION
		UPDATE UsersGames
		SET Cash -= @price WHERE Id = @UGId

		INSERT INTO UserGameItems
		SELECT Id, @UGId FROM Items WHERE MinLevel BETWEEN 19 AND 21

	COMMIT
END

SELECT i.Name AS 'Item Name' 
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugi.ItemId
WHERE u.Username = 'Stamat' AND G.[Name] = 'Safflower'
ORDER BY i.Name