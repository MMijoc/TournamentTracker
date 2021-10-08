CREATE PROCEDURE [dbo].[spTournamentEntries_Insert]
	@TournamentId INT,
	@TeamId INT,
	@Id INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].TournamentEntries(TournamentId, TeamId)
	VALUES (@TournamentId, @TeamId);

	SELECT @Id = SCOPE_IDENTITY();

END
