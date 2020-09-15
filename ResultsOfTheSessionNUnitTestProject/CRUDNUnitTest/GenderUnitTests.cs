using DAL.ORM.Models;
using NUnit.Framework;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Gender"/> model</summary>
    [TestFixture]
    public class GenderUnitTests : CRUDUnitTestData
    {
        [Test]
        [TestCase("Unknown")]
        public void CreateGender_IsTrue_Test(string newGenderName)
        {
            Assert.IsTrue(DaoFactory.GetGender().TryCreateAsync(new Gender(newGenderName)).Result);
        }

        [Test]
        [TestCase(1)]
        public void ReadGender_IsNotNull_Test(int genderId)
        {
            Assert.IsNotNull(DaoFactory.GetGender().TryReadAsync(genderId).Result);
        }

        [Test]
        [TestCase(20)]
        public void ReadGender_IsNull_Test(int genderId)
        {
            Assert.IsNull(DaoFactory.GetGender().TryReadAsync(genderId).Result);
        }

        [Test]
        [TestCase(3, "UnknownAfterUpdate")]
        public void UpdateGender_IsTrue_Test(int genderId, string genderName)
        {
            Assert.IsTrue(DaoFactory.GetGender().TryUpdateAsync(new Gender(genderId, genderName)).Result);
        }

        [Test]
        [TestCase(23, "UnknownAfterUpdate")]
        public void UpdateGender_IsFalse_Test(int genderId, string genderName)
        {
            Assert.IsFalse(DaoFactory.GetGender().TryUpdateAsync(new Gender(genderId, genderName)).Result);
        }

        [Test]
        [TestCase(3)]
        public void DeleteGender_IsTrue_Test(int genderId)
        {
            Assert.IsTrue(DaoFactory.GetGender().TryDeleteAsync(genderId).Result);
        }

        [Test]
        [TestCase(10)]
        public void DeleteGender_IsFalse_Test(int genderId)
        {
            Assert.IsFalse(DaoFactory.GetGender().TryDeleteAsync(genderId).Result);
        }

        [Test]
        public void ReadAllGenders_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetGender().TryReadAllAsync().Result);
        }
    }
}