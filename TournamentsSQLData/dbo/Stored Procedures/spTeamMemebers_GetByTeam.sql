CREATE PROCEDURE [dbo].[spTeamMemebers_GetByTeam]
	@TeamId INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT	P.Id,
			P.FirstName,
			P.LastName,
			P.EmailAddress,
			P.CellphoneNumber

	FROM [dbo].[TeamMember] TM
	JOIN [dbo].[People] P
	ON P.[Id] = TM.[PersonId]
	WHERE TM.[TeamId] = @TeamId
END
