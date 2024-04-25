CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY,
	[Nom] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[DateNaissance] DATE NOT NULL,
	[PasswordHash] BINARY(64) NOT NULL,
	[SecurityStamp] UNIQUEIDENTIFIER NOT NULL,
	[RoleId] INT,

	CONSTRAINT [PK_UTilisateur] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Utilisareur_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role]([Id])
) 
