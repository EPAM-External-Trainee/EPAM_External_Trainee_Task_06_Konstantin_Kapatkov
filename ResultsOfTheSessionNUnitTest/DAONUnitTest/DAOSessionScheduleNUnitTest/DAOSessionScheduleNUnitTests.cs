using NUnit.Framework;
using ResultsOfTheSession.ORM.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest.DAONUnitTest.DAOSessionScheduleNUnitTest
{
    [TestFixture]
    public class DAOSessionScheduleNUnitTests : DAOTest
    {
        [TestCase(2, 2, 2, 2021, 12, 12, 2)]
        public void CreateSessionSchedule_Test(int sessionId, int groupId, int subjectId, int year, int month, int day, int knowledgeAssessmentFormId)
        {
            SessionSchedule sessionSchedule = new SessionSchedule(sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId);
            bool result = Task.Run(async () => await DaoFactoryTest.GetSessionSchedule().CreateAsync(sessionSchedule)).Result;
            SessionSchedule expectedSessionSchedule = Task.Run(async () => await DaoFactoryTest.GetSessionSchedule().ReadAllAsync()).Result.Last();
            Assert.IsTrue(result && sessionSchedule.SessionId == expectedSessionSchedule.SessionId && sessionSchedule.SubjectId == expectedSessionSchedule.SubjectId && sessionSchedule.GroupId == expectedSessionSchedule.GroupId && sessionSchedule.Date == expectedSessionSchedule.Date && sessionSchedule.KnowledgeAssessmentFormId == expectedSessionSchedule.KnowledgeAssessmentFormId);
        }

        [TestCase(2, 1, 1, 2, 15, 12, 2019, 2)]
        public void ReadSessionSchedule_Test(int id, int sessionId, int groupId, int subjectId, int day, int month, int year, int knowledgeAssessmentFormId)
        {
            SessionSchedule sessionSchedule = Task.Run(async () => await DaoFactoryTest.GetSessionSchedule().ReadAsync(id)).Result;
            Assert.AreEqual(sessionSchedule, new SessionSchedule(id, sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId));
        }

        [TestCase(2, 1, 1, 2, 19, 12, 2019, 2)]
        public void UpdateSessionSchedule_Test(int id, int sessionId, int groupId, int subjectId, int day, int month, int year, int knowledgeAssessmentFormId)
        {
            SessionSchedule sessionSchedule = new SessionSchedule(id, sessionId, groupId, subjectId, new DateTime(year, month, day), knowledgeAssessmentFormId);
            bool result = Task.Run(async () => await DaoFactoryTest.GetSessionSchedule().UpdateAsync(sessionSchedule)).Result;
            Assert.AreEqual(sessionSchedule, Task.Run(async () => await DaoFactoryTest.GetSessionSchedule().ReadAsync(id)).Result);
            Assert.IsTrue(result);
        }

        [TestCase(3)]
        public void DeleteSessionSchedule_Test(int id)
        {
            bool result = Task.Run(async () => await DaoFactoryTest.GetSessionSchedule().DeleteAsync(id)).Result;
            Assert.IsNull(Task.Run(async () => await DaoFactoryTest.GetSessionSchedule().ReadAsync(id)).Result);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadAllSessionSchedule_Test()
        {
            IEnumerable<SessionSchedule> result = Task.Run(async () => await DaoFactoryTest.GetSessionSchedule().ReadAllAsync().ConfigureAwait(false)).Result;
            Assert.IsTrue(result != null && result.Count() != 0);
        }
    }
}