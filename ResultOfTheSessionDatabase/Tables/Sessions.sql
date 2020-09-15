CREATE TABLE [dbo].[Sessions]
(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[AcademicYear] [nvarchar](max) NULL,
    CONSTRAINT [PK_dbo.Sessions] PRIMARY KEY CLUSTERED ([Id] ASC)
)