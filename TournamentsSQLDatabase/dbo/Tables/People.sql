CREATE TABLE [dbo].[People] (
	[Id]              INT             IDENTITY (1, 1) NOT NULL,
	[FirstName]       NVARCHAR (100)  NOT NULL,
	[LastName]        NVARCHAR (100)  NOT NULL,
	[EmailAddress]    NVARCHAR (1000) NOT NULL,
	[CellphoneNumber] NVARCHAR (25)   NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
);
