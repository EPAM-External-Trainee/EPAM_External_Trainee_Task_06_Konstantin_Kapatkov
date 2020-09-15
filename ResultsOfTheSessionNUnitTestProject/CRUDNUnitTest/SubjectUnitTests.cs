using DAL.ORM.Models;
using NUnit.Framework;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Subject"/> model</summary>
    [TestFixture]
    public class SubjectUnitTests : CRUDUnitTestData
    {
        [Test]
        [TestCase("Unknown")]
        public void CreateSubject_IsTrue_Test(string name)
        {
            Assert.IsTrue(DaoFactory.GetSubject().TryCreateAsync(new Subject(name)).Result);
        }

        [Test]
        [TestCase(1)]
        public void ReadSubject_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetSubject().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(10)]
        public void ReadSubject_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetSubject().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(1, "Unknown")]
        public void UpdateSubject_IsTrue_Test(int id, string name)
        {
            Assert.IsTrue(DaoFactory.GetSubject().TryUpdateAsync(new Subject(id, name)).Result);
        }

        [Test]
        [TestCase(10, "Unknown")]
        public void UpdateSubject_IsFalse_Test(int id, string name)
        {
            Assert.IsFalse(DaoFactory.GetSubject().TryUpdateAsync(new Subject(id, name)).Result);
        }

        [Test]
        [TestCase(1)]
        public void DeleteSubject_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetSubject().TryDeleteAsync(id).Result);
        }

        [Test]
        [TestCase(10)]
        public void DeleteSubject_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetSubject().TryDeleteAsync(id).Result);
        }

        [Test]
        public void ReadAllSubjects_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetSubject().TryReadAllAsync().Result);
        }
    }
}