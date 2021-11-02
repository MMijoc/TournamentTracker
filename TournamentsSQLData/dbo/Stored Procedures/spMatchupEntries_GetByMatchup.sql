CREATE PROCEDURE [dbo].[spMatchupEntries_GetByMatchup]
	@MatchupId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[MatchupEntries] ME
	WHERE ME.MatchupId = @MatchupId
END