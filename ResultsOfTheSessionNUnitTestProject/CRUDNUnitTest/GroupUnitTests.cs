using DAL.ORM.Models;
using NUnit.Framework;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Group"/> model</summary>
    [TestFixture]
    public class GroupUnitTests : CRUDUnitTestData
    {
        [Test]
        [TestCase("Unknown")]
        public void CreateGroup_IsTrue_Test(string groupName)
        {
            Assert.IsTrue(DaoFactory.GetGroup().TryCreateAsync(new Group(groupName)).Result);
        }

        [Test]
        [TestCase(1)]
        public void ReadGroup_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetGroup().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(10)]
        public void ReadGroup_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetGroup().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(1, "Unknown")]
        public void UpdateGroup_IsTrue_Test(int id, string groupName)
        {
            Assert.IsTrue(DaoFactory.GetGroup().TryUpdateAsync(new Group(id, groupName)).Result);
        }

        [Test]
        [TestCase(10, "Unknown")]
        public void UpdateGroup_IsFalse_Test(int id, string groupName)
        {
            Assert.IsFalse(DaoFactory.GetGroup().TryUpdateAsync(new Group(id, groupName)).Result);
        }

        [Test]
        [TestCase(1)]
        public void DeleteGroup_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetGroup().TryDeleteAsync(id).Result);
        }

        [Test]
        [TestCase(10)]
        public void DeleteGroup_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetGroup().TryDeleteAsync(id).Result);
        }

        [Test]
        public void ReadAllGroups_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetGroup().TryReadAllAsync().Result);
        }
    }
}