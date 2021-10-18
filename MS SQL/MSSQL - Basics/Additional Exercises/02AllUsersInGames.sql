SELECT g.[Name] AS Game
	   ,gt.[Name] AS [Game Type]
	   ,u.Username
	   ,ug.[Level]
	   ,ug.Cash
	   ,c.[Name] AS [Character]
  FROM UsersGames AS ug
  LEFT JOIN Games AS g ON ug.GameId = g.Id
  LEFT JOIN Characters AS c ON ug.CharacterId = c.Id
  LEFT JOIN Users AS u ON ug.UserId = u.Id
  LEFT JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
 ORDER BY ug.[Level] DESC, u.Username, g.[Name]

  SELECT * FROM Games  
  SELECT * FROM GameTypes 
  SELECT * FROM UsersGames
  ORDER BY Level
  SELECT * FROM Characters
  SELECT * FROM [Statistics]

  SELECT g.[Name] AS Game
	   ,gt.[Name] AS [Game Type]
	   ,u.Username
	   ,ug.[Level]
	   ,ug.Cash
	   ,c.[Name] AS [Character]
	   FROM Users AS u
  RIGHT JOIN UsersGames AS ug ON   u.Id = ug.Id
  LEFT JOIN Games AS g ON ug.GameId = g.Id
  LEFT JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
  LEFT JOIN Characters AS c ON ug.CharacterId = c.Id
 ORDER BY ug.[Level] DESC, u.Username, g.[Name]