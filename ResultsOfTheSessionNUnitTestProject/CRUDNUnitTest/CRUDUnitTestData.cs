using DAL.DAO.Models;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes common data for CRUD tests</summary>
    public abstract class CRUDUnitTestData
    {
        /// <summary>Dao factory instance</summary>
        protected DaoFactory DaoFactory { get; } = DaoFactory.GetInstance(@"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;");
    }
}