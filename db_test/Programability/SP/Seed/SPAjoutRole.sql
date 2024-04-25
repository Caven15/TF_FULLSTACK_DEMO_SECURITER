CREATE PROCEDURE [dbo].[SPAjoutRole]
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT TOP 1 [Nom] FROM [dbo].[Role])
    BEGIN
        PRINT 'Les rôles existent déjà :-(';
        RETURN;
    END
    INSERT INTO [dbo].[Role] (Nom)
    VALUES ('Utilisateur'),
           ('Modérateur'),
           ('Administrateur');
    PRINT 'Les rôles ont été ajoutés avec succès :-)';
END
