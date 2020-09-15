using DAL.ORM.Models.SessionInfo;
using NUnit.Framework;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Session"/> model</summary>
    [TestFixture]
    public class SessionUnitTests : CRUDUnitTestData
    {
        [Test]
        [TestCase("Unknown", "2008/2009")]
        public void CreateSession_IsTrue_Test(string name, string academicYear)
        {
            Assert.IsTrue(DaoFactory.GetSession().TryCreateAsync(new Session(name, academicYear)).Result);
        }

        [Test]
        [TestCase(1)]
        public void ReadSession_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetSession().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(10)]
        public void ReadSession_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetSession().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(1, "Unknown", "2011/2012")]
        public void UpdateSession_IsTrue_Test(int id, string name, string academicYear)
        {
            Assert.IsTrue(DaoFactory.GetSession().TryUpdateAsync(new Session(id, name, academicYear)).Result);
        }

        [Test]
        [TestCase(10, "Unknown", "2011/2012")]
        public void UpdateSession_IsFalse_Test(int id, string name, string academicYear)
        {
            Assert.IsFalse(DaoFactory.GetSession().TryUpdateAsync(new Session(id, name, academicYear)).Result);
        }

        [Test]
        [TestCase(1)]
        public void DeleteSession_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetSession().TryDeleteAsync(id).Result);
        }

        [Test]
        [TestCase(10)]
        public void DeleteSession_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetSession().TryDeleteAsync(id).Result);
        }

        [Test]
        public void ReadAllSessions_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetSession().TryReadAllAsync().Result);
        }
    }
}