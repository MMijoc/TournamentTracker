CREATE PROCEDURE [dbo].[spMatchups_Update]
	@Id INT,
	@WinnerId INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Matchups]
	SET WinnerId = @WinnerId
	WHERE Id = @Id

END