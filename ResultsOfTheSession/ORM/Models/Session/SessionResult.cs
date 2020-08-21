using ResultsOfTheSession.ORM.Interfaces.Session;

namespace ResultsOfTheSession.ORM.Models.Session
{
    public class SessionResult : ISessionResult
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int StudentId { get; set; }

        public string Assessment { get; set; }
    }
}