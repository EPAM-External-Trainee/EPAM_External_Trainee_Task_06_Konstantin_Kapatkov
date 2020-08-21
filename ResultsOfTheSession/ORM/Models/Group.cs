using ResultsOfTheSession.ORM.Interfaces;

namespace ResultsOfTheSession.ORM.Models
{
    public class Group : IGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}