CREATE PROCEDURE [dbo].[SPUserRegister]
	@Nom NVARCHAR(50),
	@Email NVARCHAR(50),
	@DateNaissance DATE,
	@Password NVARCHAR(30)
AS
BEGIN
	DECLARE @PasswordHash BINARY(64), @SecurityStamp UNIQUEIDENTIFIER

	SET @SecurityStamp = NEWID()
	SET @PasswordHash = dbo.FHasher(TRIM(@Password), @SecurityStamp)

	INSERT INTO [User] (Nom, Email, DateNaissance, PasswordHash, SecurityStamp)
	VALUES (TRIM(@Nom), TRIM(@Email), @DateNaissance, @PasswordHash, @SecurityStamp)
END
