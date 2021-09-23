CREATE PROCEDURE [dbo].[spPeople_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[People]
END