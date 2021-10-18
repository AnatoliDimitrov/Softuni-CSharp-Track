CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15, 5), @rate FLOAT(30), @years INT)
RETURNS DECIMAL(20,4)
BEGIN 
	DECLARE @result DECIMAL(20,4) =@sum * (POWER((@rate + 1), @years))
	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)