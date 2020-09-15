using DAL.ORM.Interfaces.SessionInfo;
using System;

namespace DAL.ORM.Models.SessionInfo
{
    /// <summary>Class describes session schedule model</summary>
    public class SessionSchedule : ISessionSchedule
    {
        /// <summary>Default constructor</summary>
        public SessionSchedule()
        {
        }

        /// <summary>Creating an instance of <see cref="SessionSchedule"/> via session id, group id, date and knowledge assessment form id</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="groupId">Group id</param>
        /// <param name="subjectId">Subject id</param>
        /// <param name="date">Date of exam or credit</param>
        /// <param name="knowledgeAssessmentFormId">Knowledge assessment form id</param>
        public SessionSchedule(int sessionId, int groupId, int subjectId, DateTime date, int knowledgeAssessmentFormId) => (SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId) = (sessionId, groupId, subjectId, date, knowledgeAssessmentFormId);

        /// <summary>Creating an instance of <see cref="SessionSchedule"/> via id, session id, group id, date, knowledge assessment form id and examiner id</summary>
        /// <param name="id">Session schedule id</param>
        /// <param name="sessionId">Session id</param>
        /// <param name="groupId">Group id</param>
        /// <param name="subjectId">Subject id</param>
        /// <param name="date">Date of exam or credit</param>
        /// <param name="knowledgeAssessmentFormId">Knowledge assessment form id</param>
        public SessionSchedule(int id, int sessionId, int groupId, int subjectId, DateTime date, int knowledgeAssessmentFormId) => (Id, SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId) = (id, sessionId, groupId, subjectId, date, knowledgeAssessmentFormId);

        /// <inheritdoc cref="ISessionSchedule.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="ISessionSchedule.SessionId"/>
        public int SessionId { get; set; }

        /// <inheritdoc cref="ISessionSchedule.GroupId"/>
        public int GroupId { get; set; }

        /// <inheritdoc cref="ISessionSchedule.SubjectId"/>
        public int SubjectId { get; set; }

        /// <inheritdoc cref="ISessionSchedule.Date"/>
        public DateTime Date { get; set; }

        /// <inheritdoc cref="ISessionSchedule.KnowledgeAssessmentFormId"/>
        public int KnowledgeAssessmentFormId { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is SessionSchedule schedule && Id == schedule.Id && SessionId == schedule.SessionId && GroupId == schedule.GroupId && SubjectId == schedule.SubjectId && Date == schedule.Date && KnowledgeAssessmentFormId == schedule.KnowledgeAssessmentFormId;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Id, SessionId, GroupId, SubjectId, Date, KnowledgeAssessmentFormId);
    }
}