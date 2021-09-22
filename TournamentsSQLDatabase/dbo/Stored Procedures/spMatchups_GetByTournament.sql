CREATE PROCEDURE [dbo].[spMatchups_GetByTournament]
	@TournamentId INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT *
	FROM [dbo].[Matchups] M
	JOIN [dbo].[Teams] T
	ON M.Id = T.Id
	JOIN [dbo].[TournamentEntries] TE
	ON TE.TeamId = T.Id
	WHERE TE.TournamentId = @TournamentId
END
