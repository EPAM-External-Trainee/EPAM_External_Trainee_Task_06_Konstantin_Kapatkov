using ResultsOfTheSession.DAO;

namespace ResultsOfTheSessionNUnitTest.DAONUnitTest
{
    public abstract class DAOTest
    {
        protected static string ConnectionString => @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;";
        protected static DaoFactory DaoFactoryTest => DaoFactory.GetInstance(ConnectionString);
    }
}