SELECT f.CountryName
       ,co.ContinentName
	   ,f.RiversCount
	   ,f.TotalLength
  FROM
		(SELECT c.CountryName
			   ,COUNT(cr.CountryCode) AS RiversCount
			   ,CASE WHEN SUM(r.Length) IS NULL THEN 0
				ELSE  SUM(r.Length) END AS TotalLength
		  FROM Countries AS c
		  LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
		  LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
		 GROUP BY c.CountryName) AS f
  LEFT JOIN Countries AS c ON f.CountryName = c.CountryName
  JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
 ORDER BY f.RiversCount DESC, f.TotalLength DESC, f.CountryName