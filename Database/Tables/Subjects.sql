CREATE TABLE [dbo].[Subjects]
(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Subjects] PRIMARY KEY CLUSTERED ([Id] ASC)
)