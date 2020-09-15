CREATE TABLE [dbo].[SessionResults]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Assessment] [nvarchar](max) NULL,
	[SessionId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SessionResults] PRIMARY KEY CLUSTERED ([Id] ASC)
)