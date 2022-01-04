CREATE PROCEDURE [dbo].[spTeam_GetById]
	@TeamId INT
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT *
	FROM [dbo].[Teams]
	WHERE Id = @TeamId
END
