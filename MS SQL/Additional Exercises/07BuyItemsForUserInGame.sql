---------------------------------First Part--------------------------------
INSERT INTO UserGameItems
VALUES (51, 235)
        ,(71, 235)
        ,(157, 235)
        ,(184, 235)
        ,(197, 235)
        ,(223, 235)

UPDATE UsersGames
   SET Cash -= (select SUM(Price)
				FROM Items WHERE [Name] IN ('Blackguard'
					 ,'Bottomless Potion of Amplification'
					 ,'Eye of Etlich (Diablo III)'
					 ,'Gem of Efficacious Toxin'
					 ,'Golden Gorget of Leoric'
					 ,'Hellfire Amulet'))
			   WHERE Id = 235
-----------------------------------FP End-----------------------------------
-----------------------------------Second Part------------------------------
SELECT u.Username
	   ,g.[Name]
	   ,ug.Cash
	   ,i.[Name] AS [Item Name]
  FROM UsersGames AS ug
  JOIN Users AS u ON ug.UserId = u.Id
  JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
  JOIN Items AS i ON ugi.ItemId = i.Id
  JOIN Games AS g ON ug.GameId = g.Id
 WHERE g.[Name] = 'Edinburgh'
 ORDER BY i.[Name]
-----------------------------------SP End-----------------------------------