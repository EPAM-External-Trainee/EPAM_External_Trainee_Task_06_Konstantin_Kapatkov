using ResultsOfTheSession.ORM.Interfaces.Session;
using System;

namespace ResultsOfTheSession.ORM.Models.Session
{
    public class SessionResult : ISessionResult
    {
        public SessionResult(int subjectId, int studentId, string assessment) => (SubjectId, StudentId, Assessment) = (subjectId, studentId, assessment);

        public SessionResult(int id, int subjectId, int studentId, string assessment) => (Id, SubjectId, StudentId, Assessment) = (id, subjectId, studentId, assessment);

        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int StudentId { get; set; }

        public string Assessment { get; set; }

        public override bool Equals(object obj) => obj is SessionResult result && Id == result.Id && SubjectId == result.SubjectId && StudentId == result.StudentId && Assessment == result.Assessment;

        public override int GetHashCode() => HashCode.Combine(Id, SubjectId, StudentId, Assessment);

        public override string ToString() => $"Sessin result id: {Id}, subject id: {SubjectId}, student id: {StudentId}, assesment: {Assessment}.";
    }
}