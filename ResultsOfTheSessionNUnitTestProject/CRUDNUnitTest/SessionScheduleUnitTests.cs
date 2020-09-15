using DAL.ORM.Models.SessionInfo;
using NUnit.Framework;
using System;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="SessionSchedule"/> model</summary>
    [TestFixture]
    public class SessionScheduleUnitTests : CRUDUnitTestData
    {
        [Test]
        [TestCase(1, 1, 1, 2020, 12, 12, 1)]
        public void CreateSessionSchedule_IsTrue_Test(int sessionId, int groupId, int subjectId, int year, int month, int day, int knowledgeAssessmentFormId)
        {
            Assert.IsTrue(DaoFactory.GetSessionSchedule().TryCreateAsync(new SessionSchedule(sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId)).Result);
        }

        [Test]
        [TestCase(1)]
        public void ReadSessionSchedule_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetSessionSchedule().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(100)]
        public void ReadSessionSchedule_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetSessionSchedule().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(1, 1, 1, 1, 2020, 5, 22, 1)]
        public void UpdateSessionSchedule_IsTrue_Test(int id, int sessionId, int groupId, int subjectId, int year, int month, int day, int knowledgeAssessmentFormId)
        {
            Assert.IsTrue(DaoFactory.GetSessionSchedule().TryUpdateAsync(new SessionSchedule(id, sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId)).Result);
        }

        [Test]
        [TestCase(100, 1, 1, 1, 2020, 5, 22, 1)]
        public void UpdateSessionSchedule_IsFalse_Test(int id, int sessionId, int groupId, int subjectId, int year, int month, int day, int knowledgeAssessmentFormId)
        {
            Assert.IsFalse(DaoFactory.GetSessionSchedule().TryUpdateAsync(new SessionSchedule(id, sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId)).Result);
        }

        [Test]
        [TestCase(1)]
        public void UpdateSessionSchedule_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetSessionSchedule().TryDeleteAsync(id).Result);
        }

        [Test]
        [TestCase(100)]
        public void UpdateSessionSchedule_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetSessionSchedule().TryDeleteAsync(id).Result);
        }

        [Test]
        public void ReadAllSessionSchedules_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetSessionSchedule().TryReadAllAsync().Result);
        }
    }
}