CREATE TABLE [dbo].[TournamentPrizes] (
	[Id]           INT IDENTITY (1, 1) NOT NULL,
	[TournamentId] INT NOT NULL,
	[PrizeId]      INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([PrizeId]) REFERENCES [dbo].[Prizes] ([Id]),
	FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id])
);
