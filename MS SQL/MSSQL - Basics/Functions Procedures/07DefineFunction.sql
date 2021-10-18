CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(1000), @word VARCHAR(1000))
RETURNS INT
BEGIN
	DECLARE @True TINYINT = 1
	DECLARE @Length INT = LEN(@Word)
	DECLARE @Counter INT = 1

	WHILE (@Counter <= @Length)
	BEGIN
		DECLARE @CurrentChar VARCHAR(1) = SUBSTRING(@Word, @Counter, 1)
		IF (@setOfLetters NOT LIKE '%' + @CurrentChar + '%')
			SET @True = 0 
		SET @Counter += 1
	END

	RETURN @True
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')