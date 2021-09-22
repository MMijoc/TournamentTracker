CREATE PROCEDURE [dbo].[spTournaments_GetAll]
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT *
	FROM [dbo].[Tournaments]
END
