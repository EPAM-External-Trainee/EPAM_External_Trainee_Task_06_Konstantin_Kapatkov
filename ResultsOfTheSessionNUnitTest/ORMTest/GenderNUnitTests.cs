using NUnit.Framework;
using ResultsOfTheSession.DAO;
using ResultsOfTheSession.DAO.Interfaces;
using ResultsOfTheSession.ORM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            bool result = Task.Run(async () => await _daoGender.CreateAsync(gender).ConfigureAwait(false)).Result;
        }

        [Test]
        public void ReadGender_Test()
        {
            Gender gender = Task.Run(async () => await _daoGender.ReadAsync(1).ConfigureAwait(false)).Result;
        }

        [Test]
        public void UpdateGender_Test()
        {
            Gender gender = new Gender(1, "Unknown");
            bool result = Task.Run(async () => await _daoGender.UpdateAsync(gender).ConfigureAwait(false)).Result;
        }

        [Test]
        public void DeleteGender_Test()
        {
            bool result = Task.Run(async () => await _daoGender.DeleteAsync(3).ConfigureAwait(false)).Result;
        }

        [Test]
        public void ReadAllGender_Test()
        {
           IEnumerable<Gender> result = Task.Run(async () => await _daoGender.ReadAllAsync().ConfigureAwait(false)).Result;
        }
    }
}