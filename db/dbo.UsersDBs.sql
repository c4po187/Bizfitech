CREATE TABLE [dbo].[UsersDBs] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [Name]          NCHAR (50) NOT NULL,
    [Email]         NCHAR (30) NOT NULL,
    [DateOfBirth]   DATE       NOT NULL,
    [TwitterHandle] NCHAR (20) NULL,
    [FavNetflix]    NCHAR (50) NULL,
    [NumCats]       INT        NOT NULL,
    [DataShare]     BIT        DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

