using NUnit.Framework;
using ResultsOfTheSession.ORM.Models.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest.DAONUnitTest.DAOSessionNUnitTest
{
    [TestFixture]
    public class DAOSessionNUnitTests : DAOTest
    {
        [TestCase("Unknown", "2020")]
        public void CreateSession_Test(string sessionName, string sessionAcaddemicYear)
        {
            Session session = new Session(sessionName, sessionAcaddemicYear);
            bool result = Task.Run(async () => await DaoFactoryTest.GetSession().CreateAsync(session).ConfigureAwait(false)).Result;
            Session expectedSession = Task.Run(async () => await DaoFactoryTest.GetSession().ReadAllAsync().ConfigureAwait(false)).Result.Last();
            Assert.IsTrue(result && session.Name == expectedSession.Name && session.AcademicYear == expectedSession.AcademicYear);
        }

        [TestCase(1, "Winter examination and credit session", "2019")]
        public void ReadSession_Test(int id, string sessionName, string sessionAcaddemicYear)
        {
            Session session = Task.Run(async () => await DaoFactoryTest.GetSession().ReadAsync(id).ConfigureAwait(false)).Result;
            Assert.AreEqual(session, new Session(id, sessionName, sessionAcaddemicYear));
        }

        [TestCase(1, "Unknown", "2021")]
        public void UpdateSession_Test(int id, string sessionName, string sessionAcaddemicYear)
        {
            Session session = new Session(id, sessionName, sessionAcaddemicYear);
            bool result = Task.Run(async () => await DaoFactoryTest.GetSession().UpdateAsync(session).ConfigureAwait(false)).Result;
            Assert.AreEqual(session, Task.Run(async () => await DaoFactoryTest.GetSession().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [TestCase(1)]
        public void DeleteSession_Test(int id)
        {
            bool result = Task.Run(async () => await DaoFactoryTest.GetSession().DeleteAsync(id).ConfigureAwait(false)).Result;
            Assert.IsNull(Task.Run(async () => await DaoFactoryTest.GetSession().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadAllSession_Test()
        {
            IEnumerable<Session> result = Task.Run(async () => await DaoFactoryTest.GetSession().ReadAllAsync().ConfigureAwait(false)).Result;
            Assert.IsTrue(result != null && result.Count() != 0);
        }
    }
}