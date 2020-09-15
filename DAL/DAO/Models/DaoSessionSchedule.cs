using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    /// <summary>Class describes Dao <see cref="SessionSchedule"/> functionality</summary>
    public class DaoSessionSchedule : Dao<SessionSchedule>
    {
        /// <summary>Creating an instance of <see cref="DaoSessionSchedule"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoSessionSchedule(string connectionString) : base(connectionString)
        {
        }
    }
}