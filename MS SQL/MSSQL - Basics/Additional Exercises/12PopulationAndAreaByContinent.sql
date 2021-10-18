SELECT *
  FROM
		(SELECT ContinentName
			   ,SUM(AreaInSqKm) AS CountriesArea
			   ,SUM(CAST([Population] AS BIGINT)) AS CountriesPopulation
		  FROM Continents AS co
		  JOIN Countries AS c ON co.ContinentCode = c.ContinentCode
		 GROUP BY ContinentName) AS f
 ORDER BY CountriesPopulation DESC