using NUnit.Framework;
using ResultsOfTheSession.ORM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest.DAONUnitTest.DAOSubjectNUnitTest
{
    [TestFixture]
    public class DAOSubjectNUnitTests : DAOTest
    {
        [TestCase("Unknown")]
        public void CreateSubject_Test(string subjectName)
        {
            Subject subject = new Subject(subjectName);
            bool result = Task.Run(async () => await DaoFactoryTest.GetSubject().CreateAsync(subject).ConfigureAwait(false)).Result;
            Assert.AreEqual(subject.Name, Task.Run(async () => await DaoFactoryTest.GetSubject().ReadAllAsync().ConfigureAwait(false)).Result.Last().Name);
            Assert.IsTrue(result);
        }

        [TestCase(1, "Algorithms and data structures")]
        public void ReadSubject_Test(int id, string subjectName)
        {
            Subject subject = Task.Run(async () => await DaoFactoryTest.GetSubject().ReadAsync(id).ConfigureAwait(false)).Result;
            Assert.AreEqual(subject, new Subject(id, subjectName));
        }

        [TestCase(1, "Unknown")]
        public void UpdateSubject_Test(int id, string subjectName)
        {
            Subject subject = new Subject(id, subjectName);
            bool result = Task.Run(async () => await DaoFactoryTest.GetSubject().UpdateAsync(subject).ConfigureAwait(false)).Result;
            Assert.AreEqual(subject, Task.Run(async () => await DaoFactoryTest.GetSubject().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [TestCase(1)]
        public void DeleteSubject_Test(int id)
        {
            bool result = Task.Run(async () => await DaoFactoryTest.GetSubject().DeleteAsync(id).ConfigureAwait(false)).Result;
            Assert.IsNull(Task.Run(async () => await DaoFactoryTest.GetSubject().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadAllGroups_Test()
        {
            IEnumerable<Subject> result = Task.Run(async () => await DaoFactoryTest.GetSubject().ReadAllAsync().ConfigureAwait(false)).Result;
            Assert.IsTrue(result != null && result.Count() != 0);
        }
    }
}