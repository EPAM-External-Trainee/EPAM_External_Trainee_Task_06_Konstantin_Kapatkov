ALTER TABLE [dbo].[SessionResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionResults_dbo.Sessions_SessionId] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionResults] CHECK CONSTRAINT [FK_dbo.SessionResults_dbo.Sessions_SessionId]
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