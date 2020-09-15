using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    /// <summary>Class describes Dao <see cref="Subject"/> functionality</summary>
    public class DaoSubject : Dao<Subject>
    {
        /// <summary>Creating an instance of <see cref="DaoSubject"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoSubject(string connectionString) : base(connectionString)
        {
        }
    }
}