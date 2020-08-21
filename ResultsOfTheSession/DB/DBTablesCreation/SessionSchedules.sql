USE [ResultSession]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SessionSchedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[KnowledgeAssessmentFormId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SessionSchedules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.Groups_GroupId]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.KnowledgeAssessmentForms_KnowledgeAssessmentFormId] FOREIGN KEY([KnowledgeAssessmentFormId])
REFERENCES [dbo].[KnowledgeAssessmentForms] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.KnowledgeAssessmentForms_KnowledgeAssessmentFormId]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.Sessions_SessionId] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.Sessions_SessionId]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.Subjects_SubjectId]
GO