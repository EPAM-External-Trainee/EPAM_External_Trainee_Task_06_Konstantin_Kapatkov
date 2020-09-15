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