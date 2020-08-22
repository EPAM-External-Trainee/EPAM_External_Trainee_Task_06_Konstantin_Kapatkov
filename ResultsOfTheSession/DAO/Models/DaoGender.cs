using ResultsOfTheSession.ORM.Models;

namespace ResultsOfTheSession.DAO.Models
{
    public class DaoGender : Dao<Gender>
    {
        public DaoGender(string connectionString) : base(connectionString) { }
    }
}