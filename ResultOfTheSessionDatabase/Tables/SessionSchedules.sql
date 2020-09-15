CREATE TABLE [dbo].[SessionSchedules]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[KnowledgeAssessmentFormId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SessionSchedules] PRIMARY KEY CLUSTERED ([Id] ASC)
)