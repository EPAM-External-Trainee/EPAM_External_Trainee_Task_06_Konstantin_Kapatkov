CREATE TABLE [dbo].[Groups]
(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Groups] PRIMARY KEY CLUSTERED ([Id] ASC)
)