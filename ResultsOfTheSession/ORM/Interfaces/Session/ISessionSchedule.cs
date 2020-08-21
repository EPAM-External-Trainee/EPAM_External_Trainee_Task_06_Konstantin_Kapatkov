using System;

namespace ResultsOfTheSession.ORM.Interfaces.Session
{
    public interface ISessionSchedule
    {
        int Id { get; set; }

        int SessionId { get; set; }

        int GroupId { get; set; }

        int SubjectId { get; set; }

        DateTime Date { get; set; }

        int KnowledgeAssessmentFormId { get; set; }
    }
}