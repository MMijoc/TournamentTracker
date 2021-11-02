CREATE PROCEDURE [dbo].[spTournamentPrizes_Insert]
	@TournamentId INT,
	@PrizeId INT,
	@Id INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[TournamentPrizes] (TournamentId, PrizeId)
	VALUES (@TournamentId, @PrizeId);

	SELECT @Id = SCOPE_IDENTITY();

END