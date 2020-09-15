using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    /// <summary>Class describes Dao <see cref="Group"/> functionality</summary>
    public class DaoGroup : Dao<Group>
    {
        /// <summary>Creating an instance of <see cref="DaoGroup"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoGroup(string connectionString) : base(connectionString)
        {
        }
    }
}