CREATE PROCEDURE [dbo].[spTeam_GetByTournament]
	@TournamentId INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT T.*
	FROM [dbo].[Teams] T
	JOIN [dbo].[TournamentEntries] TE
	ON T.Id = TE.[TeamId]
	WHERE TE.[TournamentId] = @TournamentId

END
