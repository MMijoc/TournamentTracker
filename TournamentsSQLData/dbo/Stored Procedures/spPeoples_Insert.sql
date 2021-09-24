CREATE PROCEDURE [dbo].[spPeoples_Insert]
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@EmailAddress NVARCHAR(1000),
	@CellphoneNumber NVARCHAR(25),
	@Id INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[People] (FirstName, LastName, EmailAddress, CellphoneNumber)
	VALUES (@FirstName, @LastName, @EmailAddress, @CellphoneNumber);

	SELECT @Id = SCOPE_IDENTITY();

END