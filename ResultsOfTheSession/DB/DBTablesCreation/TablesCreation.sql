USE [ResultSession]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Genders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GenderType] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[KnowledgeAssessmentForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Form] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.KnowledgeAssessmentForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Patronymic] [nvarchar](max) NULL,
	[GenderId] [int] NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Genders_GenderId]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Groups_GroupId]
GO

CREATE TABLE [dbo].[Sessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[AcademicYear] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Sessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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