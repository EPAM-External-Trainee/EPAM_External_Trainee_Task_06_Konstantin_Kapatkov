using NUnit.Framework;
using ResultsOfTheSession.ORM.Models.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest.DAONUnitTest.DAOSessionResultNUnitTest
{
    [TestFixture]
    public class DAOSessionResultNUnitTests : DAOTest
    {
        [TestCase(2, 2, "10")]
        public void CreateSessionResult_Test(int subjectId, int studentId, string assessment)
        {
            SessionResult sessionResult = new SessionResult(subjectId, studentId, assessment);
            bool result = Task.Run(async () => await DaoFactoryTest.GetSessionResult().CreateAsync(sessionResult)).Result;
            SessionResult expectedSessionResult = Task.Run(async () => await DaoFactoryTest.GetSessionResult().ReadAllAsync()).Result.Last();
            Assert.IsTrue(result && sessionResult.StudentId == expectedSessionResult.StudentId && sessionResult.SubjectId == expectedSessionResult.SubjectId && sessionResult.Assessment == expectedSessionResult.Assessment);
        }

        [TestCase(2, 2, 1, "Passed")]
        public void ReadSessionResult_Test(int id, int subjectId, int studentId, string assessment)
        {
            SessionResult sessionResult = Task.Run(async () => await DaoFactoryTest.GetSessionResult().ReadAsync(id)).Result;
            Assert.AreEqual(sessionResult, new SessionResult(id, subjectId, studentId, assessment));
        }

        [TestCase(2, 2, 1, "Not Passed")]
        public void UpdateSessionResult_Test(int id, int subjectId, int studentId, string assessment)
        {
            SessionResult sessionResult = new SessionResult(id, subjectId, studentId, assessment);
            bool result = Task.Run(async () => await DaoFactoryTest.GetSessionResult().UpdateAsync(sessionResult)).Result;
            Assert.AreEqual(sessionResult, Task.Run(async () => await DaoFactoryTest.GetSessionResult().ReadAsync(id)).Result);
            Assert.IsTrue(result);
        }

        [TestCase(4)]
        public void DeleteSessionResult_Test(int id)
        {
            bool result = Task.Run(async () => await DaoFactoryTest.GetSessionResult().DeleteAsync(id)).Result;
            Assert.IsNull(Task.Run(async () => await DaoFactoryTest.GetSessionResult().ReadAsync(id)).Result);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadAllSessionResult_Test()
        {
            IEnumerable<SessionResult> result = Task.Run(async () => await DaoFactoryTest.GetSessionResult().ReadAllAsync().ConfigureAwait(false)).Result;
            Assert.IsTrue(result != null && result.Count() != 0);
        }
    }
}