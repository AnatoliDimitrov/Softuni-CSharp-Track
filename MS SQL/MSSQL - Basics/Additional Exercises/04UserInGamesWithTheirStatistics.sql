SELECT 
	u.Username, 
	g.[name] AS Game, 
	MAX(c.[name]) AS [Character],
	SUM(its.Strength) + MAX(gts.Strength) + MAX(cs.Strength) AS Strength,
	SUM(its.Defence) + MAX(gts.Defence) + MAX(cs.Defence) AS Defence,
	SUM(its.Speed) + MAX(gts.Speed) + MAX(cs.Speed) AS Speed,
	SUM(its.Mind) + MAX(gts.Mind) + MAX(cs.Mind) AS Mind,
	SUM(its.Luck) + MAX(gts.Luck) + MAX(cs.Luck) AS Luck
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN Games AS g ON ug.GameId = g.Id
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
JOIN [Statistics] AS gts ON gts.Id = gt.BonusStatsId
JOIN Characters AS c ON ug.CharacterId = c.Id
JOIN [Statistics] AS cs ON cs.Id = c.StatisticId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i on i.Id = ugi.ItemId
JOIN [Statistics] AS its ON its.Id = i.StatisticId
GROUP BY u.Username, g.[Name]
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC