using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    /// <summary>Class describes Dao <see cref="Student"/> functionality</summary>
    public class DaoStudent : Dao<Student>
    {
        /// <summary>Creating an instance of <see cref="DaoStudent"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoStudent(string connectionString) : base(connectionString)
        {
        }
    }
}