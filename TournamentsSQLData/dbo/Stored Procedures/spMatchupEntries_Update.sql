CREATE PROCEDURE [dbo].[spMatchupEntries_Update]
	@Id INT,
	@TeamCompetingId INT = NULL,
	@Score FLOAT = NULL
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[MatchupEntries]
	SET TeamCompetingId = @TeamCompetingId,
		Score = @Score
	WHERE Id = @Id

END