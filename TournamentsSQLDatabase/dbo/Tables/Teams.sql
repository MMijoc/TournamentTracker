CREATE TABLE [dbo].[Teams] (
	[Id]       INT            IDENTITY (1, 1) NOT NULL,
	[TeamName] NVARCHAR (100) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
);
