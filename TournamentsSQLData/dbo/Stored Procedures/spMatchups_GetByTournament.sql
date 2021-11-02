CREATE PROCEDURE [dbo].[spMatchups_GetByTournament]
	@TournamentId INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT M.*
	FROM [dbo].[Matchups] M
	WHERE M.TournamentId = @TournamentId
	ORDER BY MatchupRound
END
