SELECT f.CurrencyCode
       ,c.[Description] AS Currency
	   ,f.NumberOfCountries
  FROM
		(SELECT cu.CurrencyCode
				,COUNT(CountryName) AS NumberOfCountries
		  FROM Currencies AS cu
		  LEFT JOIN Countries AS c ON cu.CurrencyCode = c.CurrencyCode
		  GROUP BY cu.CurrencyCode) AS f
  JOIN Currencies AS c ON c.CurrencyCode= f.CurrencyCode
 ORDER BY f.NumberOfCountries DESC, c.[Description]