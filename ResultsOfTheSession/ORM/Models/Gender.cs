using ResultsOfTheSession.ORM.Interfaces;

namespace ResultsOfTheSession.ORM.Models
{
    public class Gender : IGender
    {
        public int Id { get; set; }

        public string GenderType { get; set; }
    }
}