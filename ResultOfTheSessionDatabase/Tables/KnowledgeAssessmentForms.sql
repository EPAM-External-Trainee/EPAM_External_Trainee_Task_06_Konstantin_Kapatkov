CREATE TABLE [dbo].[KnowledgeAssessmentForms]
(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Form] [nvarchar](max) NULL,
    CONSTRAINT [PK_dbo.KnowledgeAssessmentForms] PRIMARY KEY CLUSTERED ([Id] ASC)
)