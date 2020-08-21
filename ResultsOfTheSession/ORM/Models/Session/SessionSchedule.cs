using ResultsOfTheSession.ORM.Interfaces.Session;
using System;

namespace ResultsOfTheSession.ORM.Models.Session
{
    public class SessionSchedule : ISessionSchedule
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public int GroupId { get; set; }

        public int SubjectId { get; set; }

        public DateTime Date { get; set; }

        public int KnowledgeAssessmentFormId { get; set; }
    }
}