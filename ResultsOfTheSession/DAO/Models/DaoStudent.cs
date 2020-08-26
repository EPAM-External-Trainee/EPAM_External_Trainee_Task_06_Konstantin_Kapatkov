using ResultsOfTheSession.ORM.Models;

namespace ResultsOfTheSession.DAO.Models
{
    public class DaoStudent : Dao<Student>
    {
        public DaoStudent(string connectionString) : base(connectionString)
        {
        }
    }
}