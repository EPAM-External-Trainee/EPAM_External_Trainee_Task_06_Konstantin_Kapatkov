CREATE TABLE [dbo].[Genders]
(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[GenderType] [nvarchar](max) NOT NULL
    CONSTRAINT [PK_dbo.Genders] PRIMARY KEY CLUSTERED ([Id] ASC)
)