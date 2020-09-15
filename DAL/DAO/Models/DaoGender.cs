using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    /// <summary>Class describes Dao <see cref="Gender"/> functionality</summary>
    public class DaoGender : Dao<Gender>
    {
        /// <summary>Creating an instance of <see cref="DaoGender"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoGender(string connectionString) : base(connectionString)
        {
        }
    }
}