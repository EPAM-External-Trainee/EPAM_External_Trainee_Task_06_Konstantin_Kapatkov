ALTER TABLE [dbo].[Students]  WITH CHECK ADD CONSTRAINT [FK_dbo.Students_dbo.Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Genders_GenderId]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD CONSTRAINT [FK_dbo.Students_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Groups_GroupId]
GO