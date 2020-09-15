using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    public class DaoSession : Dao<Session>
    {
        public DaoSession(string connectionString) : base(connectionString)
        {
        }
    }
}