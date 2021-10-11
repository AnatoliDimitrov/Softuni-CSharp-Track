SELECT p.PeakName
       ,m.MountainRange AS Mountain
	   ,p.Elevation
  FROM Mountains AS m
  JOIN Peaks AS p ON m.Id = p.MountainId
 ORDER BY p.Elevation DESC