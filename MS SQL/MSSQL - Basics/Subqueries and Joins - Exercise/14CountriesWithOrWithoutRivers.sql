SELECT TOP (5)
	c.[CountryName]
	,r.[RiverName]
FROM [Countries] AS c
JOIN [Continents] AS co ON c.[ContinentCode] = co.[ContinentCode] AND co.[ContinentCode] = 'AF'
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
ORDER BY c.[CountryName]

