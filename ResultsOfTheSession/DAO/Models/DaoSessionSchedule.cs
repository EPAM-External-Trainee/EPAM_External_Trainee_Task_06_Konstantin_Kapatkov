using ResultsOfTheSession.ORM.Models.Session;

namespace ResultsOfTheSession.DAO.Models
{
    public class DaoSessionSchedule : Dao<SessionSchedule>
    {
        public DaoSessionSchedule(string connectionString) : base(connectionString) { }
    }
}