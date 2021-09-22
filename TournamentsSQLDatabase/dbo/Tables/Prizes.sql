CREATE TABLE [dbo].[Prizes] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [PlaceNumber]     INT            NOT NULL,
    [PlaceName]       NVARCHAR (100) NOT NULL,
    [PrizeAmount]     MONEY          NOT NULL,
    [PrizePercentage] FLOAT (53)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

