CREATE TABLE [dbo].[Students]
(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Patronymic] [nvarchar](max) NULL,
	[GenderId] [int] NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[GroupId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED ([Id] ASC)
)