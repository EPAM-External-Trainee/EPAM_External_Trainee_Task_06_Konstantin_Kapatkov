using NUnit.Framework;
using ResultsOfTheSession.ORM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest.DAONUnitTest.DAOGroupNUnitTest
{
    [TestFixture]
    public class DAOGroupNUnitTests : DAOTest
    {
        [TestCase("PL22")]
        public void CreateGroup_Test(string newGroupName)
        {
            Group group = new Group(newGroupName);
            bool result = Task.Run(async () => await DaoFactoryTest.GetGroup().CreateAsync(group).ConfigureAwait(false)).Result;
            Assert.AreEqual(group.Name, Task.Run(async () => await DaoFactoryTest.GetGroup().ReadAllAsync().ConfigureAwait(false)).Result.Last().Name);
            Assert.IsTrue(result);
        }

        [TestCase(1, "AC12")]
        public void ReadGroup_Test(int id, string groupName)
        {
            Group group = Task.Run(async () => await DaoFactoryTest.GetGroup().ReadAsync(id).ConfigureAwait(false)).Result;
            Assert.AreEqual(group, new Group(id, groupName));
        }

        [TestCase(2, "PB33")]
        public void UpdateGroup_Test(int id, string groupName)
        {
            Group group = new Group(id, groupName);
            bool result = Task.Run(async () => await DaoFactoryTest.GetGroup().UpdateAsync(group).ConfigureAwait(false)).Result;
            Assert.AreEqual(group, Task.Run(async () => await DaoFactoryTest.GetGroup().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [TestCase(1)]
        public void DeleteGroup_Test(int id)
        {
            bool result = Task.Run(async () => await DaoFactoryTest.GetGroup().DeleteAsync(id).ConfigureAwait(false)).Result;
            Assert.IsNull(Task.Run(async () => await DaoFactoryTest.GetGroup().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadAllGroups_Test()
        {
            IEnumerable<Group> result = Task.Run(async () => await DaoFactoryTest.GetGroup().ReadAllAsync().ConfigureAwait(false)).Result;
            Assert.IsTrue(result != null && result.Count() != 0);
        }
    }
}