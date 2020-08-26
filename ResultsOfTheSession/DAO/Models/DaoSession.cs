using ResultsOfTheSession.ORM.Models.Session;

namespace ResultsOfTheSession.DAO.Models
{
    public class DaoSession : Dao<Session>
    {
        public DaoSession(string connectionString) : base(connectionString)
        {
        }
    }
}