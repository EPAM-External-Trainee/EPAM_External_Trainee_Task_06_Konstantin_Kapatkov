USE [ResultSession]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SessionResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Assessment] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SessionResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[SessionResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionResults_dbo.Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionResults] CHECK CONSTRAINT [FK_dbo.SessionResults_dbo.Students_StudentId]
GO

ALTER TABLE [dbo].[SessionResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionResults_dbo.Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionResults] CHECK CONSTRAINT [FK_dbo.SessionResults_dbo.Subjects_SubjectId]
GO