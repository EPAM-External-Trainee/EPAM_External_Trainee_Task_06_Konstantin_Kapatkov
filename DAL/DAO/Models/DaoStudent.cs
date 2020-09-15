using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    public class DaoStudent : Dao<Student>
    {
        public DaoStudent(string connectionString) : base(connectionString)
        {
        }
    }
}