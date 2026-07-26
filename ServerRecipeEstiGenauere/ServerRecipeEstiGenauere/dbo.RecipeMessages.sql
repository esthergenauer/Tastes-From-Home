CREATE TABLE [dbo].[RecipeMessages] (
    [messageCode]     INT            NOT NULL,
    [recipeCode]      INT            NOT NULL,
    [messagesNumber]  INT            NOT NULL,
    [messagesText]    NVARCHAR (MAX) NULL,
    [userCode]        INT            NOT NULL,
    [messageStatus]   BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([messageCode] ASC),
    CONSTRAINT [FK_RecipeMessages_ToTable] FOREIGN KEY ([recipeCode]) REFERENCES [dbo].[Recipes] ([recipeCode]),
    CONSTRAINT [FK_RecipeMessages_ToTable_1] FOREIGN KEY ([userCode]) REFERENCES [dbo].[WebUser] ([userCode])
);

