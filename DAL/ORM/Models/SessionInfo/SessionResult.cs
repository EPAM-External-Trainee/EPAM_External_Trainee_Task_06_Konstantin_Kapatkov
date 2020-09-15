using DAL.ORM.Interfaces.SessionInfo;

namespace DAL.ORM.Models.SessionInfo
{
    /// <summary>Class describes session result model</summary>
    public class SessionResult : ISessionResult
    {
        /// <summary>Default constructor</summary>
        public SessionResult()
        {
        }

        /// <summary>Creating an instance of <see cref="SessionResult"/> via subject id, student id, assessment and session id</summary>
        /// <param name="subjectId">Subject id</param>
        /// <param name="studentId">Student id</param>
        /// <param name="assessment">Assessment</param>
        /// <param name="sessionId">Session id</param>
        public SessionResult(int subjectId, int studentId, string assessment, int sessionId) => (SubjectId, StudentId, Assessment, SessionId) = (subjectId, studentId, assessment, sessionId);

        /// <summary>Creating an instance of <see cref="SessionResult"/> via id, subject id, student id, assessment and session id</summary>
        /// <param name="id">Session result id</param>
        /// <param name="subjectId">Subject id</param>
        /// <param name="studentId">Student id</param>
        /// <param name="assessment">Assessment</param>
        /// <param name="sessionId">Session id</param>
        public SessionResult(int id, int subjectId, int studentId, string assessment, int sessionId) => (Id, SubjectId, StudentId, Assessment, SessionId) = (id, subjectId, studentId, assessment, sessionId);

        /// <inheritdoc cref="ISessionResult.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="ISessionResult.SubjectId"/>
        public int SubjectId { get; set; }

        /// <inheritdoc cref="ISessionResult.StudentId"/>
        public int StudentId { get; set; }

        /// <inheritdoc cref="ISessionResult.Assessment"/>
        public string Assessment { get; set; }

        /// <inheritdoc cref="ISessionResult.SessionId"/>
        public int SessionId { get; set; }
    }
}