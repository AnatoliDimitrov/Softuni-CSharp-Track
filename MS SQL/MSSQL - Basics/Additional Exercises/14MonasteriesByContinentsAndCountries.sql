--------------------------TASK 1

UPDATE Countries
   SET CountryName = 'Burma'
 WHERE CountryName = 'Myanmar'
 
 --------------------------TASK 2 AND 3

INSERT INTO Monasteries([Name], CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode
				   FROM Countries
				  WHERE CountryName = 'Tanzania')), 
('Myin-Tin-Daik', (SELECT CountryCode
					 FROM Countries
					WHERE CountryName = 'Myanmar'))

 --------------------------TASK 4

 SELECT co.ContinentName
        ,c.CountryName
		,COUNT(m.[Name])
   FROM Countries AS c 
   LEFT JOIN Monasteries AS m ON c.CountryCode = m.CountryCode
   LEFT JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
   WHERE c.IsDeleted <> 1
 GROUP BY co.ContinentName, c.CountryName
 ORDER BY COUNT(m.[Name]) DESC, c.CountryName

 --SELECT * FROM Countries WHERE CountryName = 'Burma'
 --SELECT * FROM Monasteries WHERE CountryCode = 'MM'

 --SELECT *
 --  FROM Countries AS c 
 --  LEFT JOIN Monasteries AS m ON c.CountryCode = m.CountryCode
 --  LEFT JOIN Continents AS co ON c.ContinentCode = co.ContinentCode