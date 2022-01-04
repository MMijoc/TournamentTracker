CREATE PROCEDURE [dbo].[spPerson_GetById]
	@PersonId INT
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT *
	FROM [dbo].[People]
	WHERE Id = @PersonId
END
