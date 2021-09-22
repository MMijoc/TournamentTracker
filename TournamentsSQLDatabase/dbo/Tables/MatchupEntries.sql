CREATE TABLE [dbo].[MatchupEntries] (
	[Id]              INT IDENTITY (1, 1) NOT NULL,
	[MatchupId]       INT NOT NULL,
	[ParentMatchupId] INT NOT NULL,
	[TeamCompetingId] INT NOT NULL,
	[Score]           INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([MatchupId]) REFERENCES [dbo].[Matchups] ([Id]),
	FOREIGN KEY ([ParentMatchupId]) REFERENCES [dbo].[Matchups] ([Id]),
	FOREIGN KEY ([TeamCompetingId]) REFERENCES [dbo].[Teams] ([Id])
);
