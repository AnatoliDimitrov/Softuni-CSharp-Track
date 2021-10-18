CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS TABLE
AS 
	RETURN SELECT SUM(r.[Cash]) AS [SumCash]
             FROM
				  (
					SELECT ROW_NUMBER() OVER(ORDER BY ug.[Cash] DESC) AS [RowNumber]
						   ,ug.[Cash]
					  FROM [Games] AS g
					JOIN [UsersGames] AS ug ON g.[Id] = ug.[GameId]
					WHERE g.[Name] = @gameName
				  ) AS r
            WHERE r.RowNumber % 2 <> 0

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

SELECT SUM(r.[Cash]) AS [SumCash]
  FROM
	  (
		SELECT ROW_NUMBER() OVER(ORDER BY ug.[Cash] DESC) AS [RowNumber]
			   ,ug.[Cash]
		  FROM [Games] AS g
		JOIN [UsersGames] AS ug ON g.[Id] = ug.[GameId]
		WHERE g.[Name] = 'Love in a mist'
	  ) AS r
 WHERE r.RowNumber % 2 <> 0