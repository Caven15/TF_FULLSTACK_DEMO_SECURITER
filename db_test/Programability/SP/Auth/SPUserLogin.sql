CREATE PROCEDURE [dbo].[SPUserLogin]
	@Email NVARCHAR(50),
	@Password NVARCHAR(30)
AS
BEGIN
	DECLARE @PasswordHash BINARY(64), @SecurityStamp UNIQUEIDENTIFIER

	SET @SecurityStamp = (SELECT SecurityStamp FROM [User] WHERE Email = @Email)
	SET @PasswordHash = dbo.FHasher(@Password, @SecurityStamp)

	IF EXISTS (SELECT TOP 1 * FROM [User] WHERE Email = @Email AND PasswordHash = @PasswordHash )
	BEGIN
		SELECT * INTO #TempUser
		FROM [User]
		WHERE Email = @Email
		ALTER TABLE #TempUser
		DROP COLUMN PasswordHash, SecurityStamp
		SELECT * FROM #TempUser 
		DROP TABLE #TempUser
	END
END
