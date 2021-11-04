CREATE PROCEDURE [dbo].[spTournaments_GetAll]
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT *
	FROM [dbo].[Tournaments]
	WHERE Active = 1
END
