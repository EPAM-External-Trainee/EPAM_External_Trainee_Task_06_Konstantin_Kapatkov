USE [ResultSession]
GO

INSERT INTO [dbo].[Genders] ([GenderType]) VALUES ('Man')
GO

INSERT INTO [dbo].[Genders] ([GenderType]) VALUES ('Woman')
GO

INSERT INTO [dbo].[Groups] ([Name]) VALUES ('AC12')
GO

INSERT INTO [dbo].[Groups] ([Name]) VALUES ('GR55')
GO

INSERT INTO [dbo].[KnowledgeAssessmentForms] ([Form]) VALUES ('Exam')
GO

INSERT INTO [dbo].[KnowledgeAssessmentForms] ([Form]) VALUES ('Credit')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Algorithms and data structures')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Probability theory and mathematical statistics')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Linear algebra and geometry')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Discrete mathematics')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Economy')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Mathematical analysis')
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Vasya', 'Vasilyev', 'Vasilyevich', 1, '1996-12-12', 1)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Petya', 'Pyatov', 'Petrovich', 1, '2005-05-01', 2)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Kolya', 'Kolev', 'Nikolaevich', 1, '2001-09-05', 1)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Mary', 'Malaeva', 'Alexandrovna', 2, '1999-04-02', 2)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Nastya', 'Krishina', 'Ivanovna', 2, '1997-08-09', 1)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Alexei', 'Alekseev', 'Alexeyevich', 1, '2005-01-02', 2)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Maxim', 'Maximov', 'Maximovich', 1, '2003-02-01', 1)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Ilya', 'Ileev', 'Ileevich', 1, '2002-08-08', 2)
GO

INSERT INTO [dbo].[Sessions] ([Name],[AcademicYear]) VALUES ('Winter examination and credit session','2019')
GO

INSERT INTO [dbo].[Sessions] ([Name],[AcademicYear]) VALUES ('Summer examination and credit session','2020')
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (1, 1, 1, '2019-12-12', 2)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (1, 1, 2, '2019-15-12', 2)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (1, 1, 3, '2019-17-12', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (1, 1, 4, '2019-19-12', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (1, 2, 1, '2019-21-12', 2)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (1, 2, 2, '2019-25-12', 2)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (1, 2, 3, '2019-27-12', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (1, 2, 4, '2019-29-12', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (2, 1, 3, '2020-08-06', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (2, 2, 3, '2020-10-06', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (2, 1, 4, '2020-12-06', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (2, 2, 4, '2020-14-06', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (2, 1, 5, '2020-15-06', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (2, 2, 5, '2020-10-06', 1)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (2, 1, 6, '2020-25-06', 2)
GO

INSERT INTO [dbo].[SessionSchedules] ([SessionId],[GroupId],[SubjectId],[Date],[KnowledgeAssessmentFormId]) VALUES (2, 2, 6, '2020-21-06', 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (1, 1, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (2, 1, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 1, 5, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 1, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 1, 4, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 1, 8, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (5, 1, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (6, 1, 'Passed', 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (1, 2, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (2, 2, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 2, 6, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 2, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 2, 6, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 2, 4, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (5, 2, 7, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (6, 2, 'Passed', 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (1, 3, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (2, 3, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 3, 9, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 3, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 3, 10, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 3, 10, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (5, 3, 8, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (6, 3, 'Passed', 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (1, 4, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (2, 4, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 4, 8, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 4, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 4, 5, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 4, 6, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (5, 4, 6, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (6, 4, 'Passed', 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (1, 5, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (2, 5, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 5, 4, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 5, 8, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 5, 4, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 5, 6, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (5, 5, 7, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (6, 5, 'Passed', 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (1, 6, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (2, 6, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 6, 4, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 6, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 6, 4, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 6, 5, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (5, 6, 8, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (6, 6, 'Passed', 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (1, 7, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (2, 7, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 7, 10, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 7, 10, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 7, 10, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 7, 10, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (5, 7, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (6, 7, 'Passed', 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (1, 8, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (2, 8, 'Passed', 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 8, 9, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (3, 8, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 8, 9, 1)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (4, 8, 9, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (5, 8, 10, 2)
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment],[SessionId]) VALUES (6, 8, 'Passed', 2)
GO