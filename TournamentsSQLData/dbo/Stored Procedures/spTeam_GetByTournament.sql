CREATE PROCEDURE [dbo].[spTeam_GetByTournament]
	@TournamentId INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT *
	FROM [dbo].[Teams] T
	JOIN [dbo].[TournamentEntries] TE
	ON T.Id = TE.[TeamId]
	WHERE TE.[TournamentId] = @TournamentId

END
