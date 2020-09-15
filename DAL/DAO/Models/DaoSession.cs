using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    /// <summary>Class describes Dao <see cref="Session"/> functionality</summary>
    public class DaoSession : Dao<Session>
    {
        /// <summary>Creating an instance of <see cref="DaoSession"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoSession(string connectionString) : base(connectionString)
        {
        }
    }
}