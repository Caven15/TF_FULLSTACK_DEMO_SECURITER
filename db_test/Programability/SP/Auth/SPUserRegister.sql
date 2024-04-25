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

    IF NOT EXISTS (SELECT 1 FROM [User])
    BEGIN
        -- Si aucun utilisateur n'existe, insérer l'utilisateur en tant qu'administrateur
        INSERT INTO [User] (Nom, Email, DateNaissance, PasswordHash, SecurityStamp, RoleId)
        VALUES (TRIM(@Nom), TRIM(@Email), @DateNaissance, @PasswordHash, @SecurityStamp, 3)
    END
    ELSE
    BEGIN
        -- Sinon, insérer l'utilisateur en tant qu'utilisateur régulier
        INSERT INTO [User] (Nom, Email, DateNaissance, PasswordHash, SecurityStamp, RoleId)
        VALUES (TRIM(@Nom), TRIM(@Email), @DateNaissance, @PasswordHash, @SecurityStamp, 1)
    END
END
