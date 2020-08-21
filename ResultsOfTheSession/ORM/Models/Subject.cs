using ResultsOfTheSession.ORM.Interfaces;

namespace ResultsOfTheSession.ORM.Models
{
    public class Subject : ISubject
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}