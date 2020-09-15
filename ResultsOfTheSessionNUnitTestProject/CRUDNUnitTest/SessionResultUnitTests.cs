using DAL.ORM.Models.SessionInfo;
using NUnit.Framework;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="SessionResult"/> model</summary>
    [TestFixture]
    public class SessionResultUnitTests : CRUDUnitTestData
    {
        [Test]
        [TestCase(1, 1, "8", 1)]
        [TestCase(2, 1, "Passed", 1)]
        public void CreateSessionResult_IsTrue_Test(int subjectId, int studentId, string assessment, int sessionId)
        {
            Assert.IsTrue(DaoFactory.GetSessionResult().TryCreateAsync(new SessionResult(subjectId, studentId, assessment, sessionId)).Result);
        }

        [Test]
        [TestCase(1)]
        public void ReadSessionResult_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetSessionResult().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(100)]
        public void ReadSessionResult_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetSessionResult().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(1, 1, 1, "5", 1)]
        public void UpdateSessionResult_IsTrue_Test(int id, int subjectId, int studentId, string assessment, int sessionId)
        {
            Assert.IsTrue(DaoFactory.GetSessionResult().TryUpdateAsync(new SessionResult(id, subjectId, studentId, assessment, sessionId)).Result);
        }

        [Test]
        [TestCase(100, 1, 1, "5", 1)]
        public void UpdateSessionResult_IsFalse_Test(int id, int subjectId, int studentId, string assessment, int sessionId)
        {
            Assert.IsFalse(DaoFactory.GetSessionResult().TryUpdateAsync(new SessionResult(id, subjectId, studentId, assessment, sessionId)).Result);
        }

        [Test]
        [TestCase(1)]
        public void DeleteSessionResult_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetSessionResult().TryDeleteAsync(id).Result);
        }

        [Test]
        [TestCase(100)]
        public void DeleteSessionResult_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetSessionResult().TryDeleteAsync(id).Result);
        }

        [Test]
        public void ReadAllSessionResults_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetSessionResult().TryReadAllAsync().Result);
        }
    }
}