  WITH AverageStats_CTE
    AS (SELECT AVG(Speed) AS AverageSpeed
               ,AVG(Luck) AS AverageLuck 
	           ,AVG(Mind) AS AverageMind
          FROM [Statistics])

SELECT *
  FROM
	(SELECT 
	        i.[Name]
			,i.Price
			,i.MinLevel
			,s.Strength
			,s.Defence
			,s.Speed
			,s.Luck
			,s.Mind
	  FROM Items AS i
	  JOIN [Statistics] AS s ON i.StatisticId = s.Id) AS f
 WHERE Speed > (SELECT AverageSpeed FROM AverageStats_CTE) AND
       Luck > (SELECT AverageLuck FROM AverageStats_CTE) AND
	   Mind > (SELECT AverageMind FROM AverageStats_CTE)
 ORDER BY [Name] 