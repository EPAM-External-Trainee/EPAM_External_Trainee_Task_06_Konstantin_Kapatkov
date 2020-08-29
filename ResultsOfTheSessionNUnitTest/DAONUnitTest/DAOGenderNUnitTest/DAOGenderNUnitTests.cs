using NUnit.Framework;
using ResultsOfTheSession.ORM.Models;
using ResultsOfTheSessionNUnitTest.DAONUnitTest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest
{
    [TestFixture]
    public class DAOGenderNUnitTests : DAOTest
    {
        [TestCase("Unknown")]
        public void CreateGender_Test(string genderTypeName)
        {
            Gender gender = new Gender(genderTypeName);
            bool result = Task.Run(async () => await DaoFactoryTest.GetGender().CreateAsync(gender).ConfigureAwait(false)).Result;
            Gender expectedGender = Task.Run(async () => await DaoFactoryTest.GetGender().ReadAllAsync().ConfigureAwait(false)).Result.Last();
            Assert.AreEqual(gender.GenderType, expectedGender.GenderType);
            Assert.IsTrue(result);
        }

        [TestCase(1, 1, "Man")]
        public void ReadGender_Test(int id, int genderId, string genderTypeName)
        {
            Gender gender = Task.Run(async () => await DaoFactoryTest.GetGender().ReadAsync(id).ConfigureAwait(false)).Result;
            Assert.AreEqual(gender, new Gender(genderId, genderTypeName));
        }

        [TestCase(1, "Unknown")]
        public void UpdateGender_Test(int id, string newGenderTypeName)
        {
            Gender gender = new Gender(id, newGenderTypeName);
            bool result = Task.Run(async () => await DaoFactoryTest.GetGender().UpdateAsync(gender).ConfigureAwait(false)).Result;
            Assert.AreEqual(gender, Task.Run(async () => await DaoFactoryTest.GetGender().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [TestCase(1)]
        public void DeleteGender_Test(int id)
        {
            bool result = Task.Run(async () => await DaoFactoryTest.GetGender().DeleteAsync(id).ConfigureAwait(false)).Result;
            Assert.IsNull(Task.Run(async () => await DaoFactoryTest.GetGender().ReadAsync(id).ConfigureAwait(false)).Result);
        }

        [Test]
        public void ReadAllGender_Test()
        {
           IEnumerable<Gender> result = Task.Run(async () => await DaoFactoryTest.GetGender().ReadAllAsync().ConfigureAwait(false)).Result;
           Assert.IsTrue(result != null && result.Count() != 0);
        }
    }
}