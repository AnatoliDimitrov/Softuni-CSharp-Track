SELECT u.Username
         ,g.[Name] AS Game 
         ,COUNT(ugi.ItemId) AS 'Items Count'
	     ,SUM(i.Price) AS 'Items Price'
  FROM Games AS g
  JOIN UsersGames AS ug ON ug.GameId = g.Id
  JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
  JOIN Items AS i ON i.Id = ugi.ItemId
  JOIN Users AS u ON u.Id = ug.UserId
 GROUP BY g.[Name], u.Username
HAVING COUNT(ugi.ItemId) >= 10
 ORDER BY COUNT(ugi.ItemId) DESC, SUM(i.Price) DESC, u.Username