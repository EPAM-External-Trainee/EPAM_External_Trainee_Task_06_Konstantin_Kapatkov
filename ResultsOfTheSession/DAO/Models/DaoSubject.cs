using ResultsOfTheSession.ORM.Models;

namespace ResultsOfTheSession.DAO.Models
{
    public class DaoSubject : Dao<Subject>
    {
        public DaoSubject(string connectionString) : base(connectionString) { }
    }
}