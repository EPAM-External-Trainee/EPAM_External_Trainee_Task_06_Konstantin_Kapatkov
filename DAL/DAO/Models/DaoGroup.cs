using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    public class DaoGroup : Dao<Group>
    {
        public DaoGroup(string connectionString) : base(connectionString)
        {
        }
    }
}