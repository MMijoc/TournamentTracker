CREATE PROCEDURE [dbo].[spPrizes_Insert]
	@PlaceNumber INT,
	@PlaceName NVARCHAR(100),
	@PrizeAmount MONEY,
	@PrizePercentage FLOAT,
	@Id INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Prizes] (PlaceNumber, PlaceName, PrizeAmount, PrizePercentage)
	VALUES (@PlaceNumber, @PlaceName, @PrizeAmount, @PrizePercentage);

	SELECT @Id = SCOPE_IDENTITY();

END