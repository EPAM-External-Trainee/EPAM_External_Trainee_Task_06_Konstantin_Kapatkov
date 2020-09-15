using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    public class DaoGender : Dao<Gender>
    {
        public DaoGender(string connectionString) : base(connectionString)
        {
        }
    }
}