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

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Higher mathematics')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Physics')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('Philosophy')
GO

INSERT INTO [dbo].[Subjects] ([Name]) VALUES ('History of Belarus')
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Vasya', 'Vasilyev', 'Vasilyevich', 1, '1996-12-12T13:10:10', 1)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Petya', 'Pyatov', 'Petrovich', 1, '2005-05-01T10:10:10', 2)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Kolya', 'Kolev', 'Nikolaevich', 1, '2001-09-05T22:19:05', 1)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Mary', 'Malaeva', 'Alexandrovna', 2, '1999-04-02T16:11:17', 2)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Nastya', 'Krishina', 'Ivanovna', 2, '1997-08-09T11:11:11', 1)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Alexei', 'Alekseev', 'Alexeyevich', 1, '2005-01-02T15:03:45', 2)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Maxim', 'Maximov', 'Maximovich', 1, '2003-02-01T09:34:12', 1)
GO

INSERT INTO [dbo].[Students] ([Name],[Surname],[Patronymic],[GenderId],[Birthday],[GroupId]) VALUES ('Ilya', 'Ileev', 'Ileevich', 1, '2002-08-08T02:14:32', 2)
GO

INSERT INTO [dbo].[Sessions] ([Name],[AcademicYear]) VALUES ('Examination and credit session','2019/2020')
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

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (1, 1, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (2, 1, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (3, 1, '5')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (4, 1, '4')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (1, 2, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (2, 2, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (3, 2, '6')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (4, 2, '6')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (1, 3, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (2, 3, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (3, 3, '9')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (4, 3, '10')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (1, 4, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (2, 4, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (3, 4, '8')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (4, 4, '5')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (1, 5, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (2, 5, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (3, 5, '4')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (4, 5, '4')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (1, 6, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (2, 6, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (3, 6, '4')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (4, 6, '4')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (1, 7, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (2, 7, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (3, 7, '10')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (4, 7, '10')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (1, 8, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (2, 8, 'Passed')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (3, 8, '9')
GO

INSERT INTO [dbo].[SessionResults] ([SubjectId],[StudentId],[Assessment]) VALUES (4, 8, '9')
GO