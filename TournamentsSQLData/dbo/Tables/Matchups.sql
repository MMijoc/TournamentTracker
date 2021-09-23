CREATE TABLE [dbo].[Matchups] (
	[Id]           INT IDENTITY (1, 1) NOT NULL,
	[WinnerId]     INT NOT NULL,
	[MatchupRound] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([WinnerId]) REFERENCES [dbo].[Teams] ([Id])
);
