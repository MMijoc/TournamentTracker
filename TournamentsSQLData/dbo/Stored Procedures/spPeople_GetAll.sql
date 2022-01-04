CREATE PROCEDURE [dbo].[spPeople_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[People]
	ORDER BY 
	[People].FirstName,
	[People].LastName
END