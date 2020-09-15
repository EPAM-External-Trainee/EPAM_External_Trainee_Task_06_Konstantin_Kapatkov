using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    public class DaoSubject : Dao<Subject>
    {
        public DaoSubject(string connectionString) : base(connectionString)
        {
        }
    }
}