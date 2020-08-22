using ResultsOfTheSession.ORM.Models;

namespace ResultsOfTheSession.DAO.Models
{
    public class DaoGroup : Dao<Group>
    {
        public DaoGroup(string connectionString) : base(connectionString) { }
    }
}