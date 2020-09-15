using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    public class DaoSessionResult : Dao<SessionResult>
    {
        public DaoSessionResult(string connectionString) : base(connectionString)
        {
        }
    }
}