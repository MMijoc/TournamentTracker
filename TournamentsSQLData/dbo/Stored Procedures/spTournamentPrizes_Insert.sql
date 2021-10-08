CREATE PROCEDURE [dbo].[spTournamentPrizes_Insert]
	@TournamentId INT,
	@PrizesId INT,
	@Id INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[TournamentPrizes] (TournamentId, PrizeId)
	VALUES (@TournamentId, @PrizesId);

	SELECT @Id = SCOPE_IDENTITY();

END