SELECT TOP (5)
	d.[Country]
	,CASE
		WHEN d.[Highest Peak Name] IS NULL THEN '(no highest peak)'
		ELSE d.[Highest Peak Name]
	 END AS [Highest Peak Name]
	 ,CASE
		WHEN d.[Highest Peak Elevation] IS NULL THEN 0
		ELSE d.[Highest Peak Elevation]
	 END AS [Highest Peak Elevation]
	 ,CASE
		WHEN d.[Mountain] IS NULL THEN '(no mountain)'
		ELSE d.[Mountain]
	 END AS [Mountain]
FROM
	(SELECT 
		c.CountryName AS [Country]
		,p.[PeakName] AS [Highest Peak Name]
		,p.[Elevation] AS [Highest Peak Elevation]
		--MAX(p.[Elevation]) AS [Highest Peak Elevation]
		,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Partitions]
		,m.[MountainRange] AS [Mountain]
	  FROM [Countries] AS c
	  LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	  LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
	  LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]) AS d
WHERE [Partitions] = 1
ORDER BY d.[Country], d.[Highest Peak Name]