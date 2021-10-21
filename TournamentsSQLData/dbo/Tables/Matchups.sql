CREATE TABLE [dbo].[Matchups] (
	[Id]           INT IDENTITY (1, 1) NOT NULL,
	[TournamentId] INT NOT NULL,
	[WinnerId]     INT NULL,
	[MatchupRound] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]),
	FOREIGN KEY ([WinnerId]) REFERENCES [dbo].[Teams] ([Id]),
	FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id])
);
