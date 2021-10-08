CREATE TABLE [dbo].[Tournaments] (
	[Id]             INT            IDENTITY (1, 1) NOT NULL,
	[TournamentName] NVARCHAR (100) NOT NULL,
	[EntryFee]       MONEY          NOT NULL,
	[Active]         BIT            NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
