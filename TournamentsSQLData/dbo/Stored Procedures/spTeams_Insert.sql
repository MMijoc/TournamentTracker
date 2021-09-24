CREATE PROCEDURE [dbo].[spTeams_Insert]
	@TeamName NVARCHAR(100),
	@Id INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Teams] (TeamName)
	VALUES (@TeamName)

	SELECT @Id = SCOPE_IDENTITY();

END