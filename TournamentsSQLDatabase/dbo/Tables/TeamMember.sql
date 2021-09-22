CREATE TABLE [dbo].[TeamMember] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [TeamId]   INT NOT NULL,
    [PersonId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([Id]),
    FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id])
);

