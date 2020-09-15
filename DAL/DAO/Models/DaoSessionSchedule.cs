using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    public class DaoSessionSchedule : Dao<SessionSchedule>
    {
        public DaoSessionSchedule(string connectionString) : base(connectionString)
        {
        }
    }
}