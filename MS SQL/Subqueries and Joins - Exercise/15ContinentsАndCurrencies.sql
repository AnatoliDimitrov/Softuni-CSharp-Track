SELECT
	a.RowNumber
	,a.[ContinentCode]
	,a.[CurrencyCode]
	,a.[CurrencyUsage]
FROM
	(SELECT 
		ROW_NUMBER() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.ContinentCode) DESC) AS RowNumber
		,c.ContinentCode
		,COUNT(c.CurrencyCode) AS [CurrencyUsage]
		,c.CurrencyCode
	FROM [Continents] AS co
	JOIN [Countries] AS c ON co.ContinentCode = c.[ContinentCode]
	GROUP BY c.ContinentCode, c.CurrencyCode) AS a

WHERE RowNumber = 1 AND [CurrencyUsage] > 0