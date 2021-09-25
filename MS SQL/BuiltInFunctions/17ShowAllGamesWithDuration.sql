SELECT [Name]
	  ,(case when DATEPART(HOUR, [Start]) >= 0 and
           DATEPART(HOUR, [Start]) < 12 then 'Morning'
      when DATEPART(HOUR, [Start]) >= 12 and
           DATEPART(HOUR, [Start]) < 18 then 'Afternoon'
      when DATEPART(HOUR, [Start]) >= 18 and
           DATEPART(HOUR, [Start]) < 24 then 'Evening'
	end) as [Part of the Day]
	  ,(case when [Duration] <= 3 then 'Extra Short'
      when [Duration] <= 6 then 'Short'
	  when [Duration] > 6 then 'Long'
      else 'Extra Long'
	end) as [Duration]
  FROM [Games]
  ORDER BY [Name], [Duration]
