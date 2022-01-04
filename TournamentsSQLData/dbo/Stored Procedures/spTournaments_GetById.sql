CREATE PROCEDURE [dbo].[spTournaments_GetById]
	@TournamentId INT
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT *
	FROM [dbo].[Tournaments]
	WHERE Id = @TournamentId
END
