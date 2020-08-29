using ResultsOfTheSession.ORM.Interfaces.Session;
using System;

namespace ResultsOfTheSession.ORM.Models.Session
{
    public class SessionSchedule : ISessionSchedule
    {
      
        public SessionSchedule(int sessionId, int groupId, int subjectId, DateTime date, int knowledgeAssessmentFormId) => (SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId) = (sessionId, groupId, subjectId, date, knowledgeAssessmentFormId);

        public SessionSchedule(int id, int sessionId, int groupId, int subjectId, DateTime date, int knowledgeAssessmentFormId) => (Id, SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId) = (id, sessionId, groupId, subjectId, date, knowledgeAssessmentFormId);

        public int Id { get; set; }

        public int SessionId { get; set; }

        public int GroupId { get; set; }

        public int SubjectId { get; set; }

        public DateTime Date { get; set; }

        public int KnowledgeAssessmentFormId { get; set; }

        public override bool Equals(object obj) => obj is SessionSchedule schedule && Id == schedule.Id && SessionId == schedule.SessionId && GroupId == schedule.GroupId && SubjectId == schedule.SubjectId && Date == schedule.Date && KnowledgeAssessmentFormId == schedule.KnowledgeAssessmentFormId;

        public override int GetHashCode() => HashCode.Combine(Id, SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId);

        public override string ToString() => $"Session schedule id: {Id}, session id {SessionId}, group id: {GroupId}, subject id: {SubjectId}, date: {Date.ToShortDateString()}, knowledge assessment form id: {KnowledgeAssessmentFormId}.";
    }
}