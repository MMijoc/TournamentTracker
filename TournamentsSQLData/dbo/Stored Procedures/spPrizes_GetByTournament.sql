CREATE PROCEDURE [dbo].[spPrizes_GetByTournament]
	@TournamentId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		p.*
	FROM		dbo.Prizes p
	INNER JOIN	dbo.TournamentPrizes tp
	ON			p.Id = tp.Id
	WHERE		tp.TournamentId = @TournamentId
END