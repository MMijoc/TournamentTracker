CREATE TABLE [dbo].[TournamentEntries] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [TournamentId] INT NOT NULL,
    [TeamId]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id]),
    FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([Id])
);

