using ResultsOfTheSession.ORM.Interfaces.Session;

namespace ResultsOfTheSession.ORM.Models.Session
{
    public class Session : ISession
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AcademicYear { get; set; }
    }
}