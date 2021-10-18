SELECT p.PeakName, r.RiverName, CONCAT(LOWER(SUBSTRING(p.PeakName,1 , LEN(p.PeakName) -1)), LOWER(r.RiverName)) AS [Mix]
FROM [Rivers] AS r
JOIN [Peaks] AS p
ON SUBSTRING(r.RiverName, 1, 1) = SUBSTRING(p.PeakName, LEN(p.PeakName), 1)
ORDER BY Mix