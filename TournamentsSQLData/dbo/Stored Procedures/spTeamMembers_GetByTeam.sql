CREATE PROCEDURE [dbo].[spTeamMembers_GetByTeam]
	@TeamId INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT *
	FROM [dbo].[TeamMembers] TM
	JOIN [dbo].[People] P
	ON P.[Id] = TM.[PersonId]
	WHERE TM.[TeamId] = @TeamId
END
