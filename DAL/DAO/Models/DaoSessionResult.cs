using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    /// <summary>Class describes Dao <see cref="SessionResult"/> functionality</summary>
    public class DaoSessionResult : Dao<SessionResult>
    {
        /// <summary>Creating an instance of <see cref="DaoSessionResult"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoSessionResult(string connectionString) : base(connectionString)
        {
        }
    }
}