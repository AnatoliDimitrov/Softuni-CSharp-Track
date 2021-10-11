SELECT i.[Name] AS [Item]
       ,i.Price
	   ,i.MinLevel
	   ,gt.[Name] AS [Forbidden Game Type]
  FROM Items AS i
  LEFT JOIN GameTypeForbiddenItems AS gtf ON i.Id = gtf.ItemId
  LEFT JOIN GameTypes AS gt ON gtf.GameTypeId = gt.Id
 ORDER BY gt.[Name] DESC, i.[Name]
