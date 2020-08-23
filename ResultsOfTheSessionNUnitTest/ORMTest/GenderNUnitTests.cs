using NUnit.Framework;
using ResultsOfTheSession.DAO;
using ResultsOfTheSession.DAO.Interfaces;
using ResultsOfTheSession.ORM.Models;

namespace ResultsOfTheSessionNUnitTest
{
    public class GenderNUnitTests
    {
        private const string _connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;";
        private static readonly DaoFactory _daoFactory = DaoFactory.GetInstance(_connectionString);
        private static readonly IDao<Gender> _daoGender = _daoFactory.GetGender();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateGender_Test()
        {
            Gender gender = new Gender("Unknown");
            _daoGender.Create(gender);
        }

        [Test]
        public void ReadGender_Test()
        {
            Gender gender = _daoGender.Read(1);
        }


    }
}