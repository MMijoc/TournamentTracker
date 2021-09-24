CREATE PROCEDURE [dbo].[spTeamMembers_Insert]
	@TeamId INT,
	@PersonId INT,
	@Id INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[TeamMembers] (TeamId, PersonId)
	VALUES (@TeamId, @PersonId)

	SELECT @Id = SCOPE_IDENTITY();

END