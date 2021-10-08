CREATE PROCEDURE [dbo].[spTournaments_Insert]
	@TournamentName NVARCHAR(100),
	@EntryFee MONEY,
	@Id INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Tournaments] (TournamentName, EntryFee, Active)
	VALUES (@TournamentName, @EntryFee, 1);

	SELECT @Id = SCOPE_IDENTITY();

END