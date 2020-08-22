using ResultsOfTheSession.ORM.Models.Session;

namespace ResultsOfTheSession.DAO.Models
{
    public class DaoSessionResult : Dao<SessionResult>
    {
        public DaoSessionResult(string connectionString) : base(connectionString) { }
    }
}