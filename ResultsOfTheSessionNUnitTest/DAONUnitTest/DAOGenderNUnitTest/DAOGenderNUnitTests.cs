using NUnit.Framework;
using ResultsOfTheSession.DAO.Interfaces;
using ResultsOfTheSession.ORM.Models;
using ResultsOfTheSessionNUnitTest.DAONUnitTest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest
{
    public class DAOGenderNUnitTests : DAOTest
    {
        private static readonly IDao<Gender> _daoGender = DaoFactoryTest.GetGender();

        [Test]
        public void CreateGender_Test()
        {
            Gender gender = new Gender("Unknown");
            bool result = Task.Run(async () => await _daoGender.CreateAsync(gender).ConfigureAwait(false)).Result;
            Assert.AreEqual(gender.GenderType, Task.Run(async () => await _daoGender.ReadAllAsync().ConfigureAwait(false)).Result.Last().GenderType);
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