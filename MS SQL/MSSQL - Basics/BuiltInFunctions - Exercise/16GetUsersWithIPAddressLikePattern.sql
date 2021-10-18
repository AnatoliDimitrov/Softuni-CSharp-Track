SELECT [Username], [IPAddress]
FROM [Users]
WHERE [IPAddress] LIKE '___.1_%._%.___'
ORDER BY [Username] 