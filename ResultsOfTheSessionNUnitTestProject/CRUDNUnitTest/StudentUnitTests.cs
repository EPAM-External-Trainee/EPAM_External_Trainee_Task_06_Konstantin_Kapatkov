using DAL.ORM.Models;
using NUnit.Framework;
using System;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="Student"/> model</summary>
    [TestFixture]
    public class StudentUnitTests : CRUDUnitTestData
    {
        [Test]
        [TestCase("Unknown", "Unknown", "Unknown", 1, 1996, 12, 12, 1)]
        public void CreateStudent_IsTrue_Test(string name, string surname, string patronymic, int genderId, int year, int month, int day, int groupId)
        {
            Assert.IsTrue(DaoFactory.GetStudent().TryCreateAsync(new Student(name, surname, patronymic, genderId, new DateTime(year, month, day), groupId)).Result);
        }

        [Test]
        [TestCase(1)]
        public void ReadStudent_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetStudent().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(100)]
        public void ReadStudent_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetStudent().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(1, "Unknown", "Unknown", "Unknown", 1, 1996, 12, 12, 1)]
        public void UpdateStudent_IsTrue_Test(int id, string name, string surname, string patronymic, int genderId, int year, int month, int day, int groupId)
        {
            Assert.IsTrue(DaoFactory.GetStudent().TryUpdateAsync(new Student(id, name, surname, patronymic, genderId, new DateTime(year, month, day), groupId)).Result);
        }

        [Test]
        [TestCase(100, "Unknown", "Unknown", "Unknown", 1, 1996, 12, 12, 1)]
        public void UpdateStudent_IsFalse_Test(int id, string name, string surname, string patronymic, int genderId, int year, int month, int day, int groupId)
        {
            Assert.IsFalse(DaoFactory.GetStudent().TryUpdateAsync(new Student(id, name, surname, patronymic, genderId, new DateTime(year, month, day), groupId)).Result);
        }

        [Test]
        [TestCase(1)]
        public void DeleteStudent_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetStudent().TryDeleteAsync(id).Result);
        }

        [Test]
        [TestCase(100)]
        public void DeleteStudent_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetStudent().TryDeleteAsync(id).Result);
        }

        [Test]
        public void ReadAllStudents_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetStudent().TryReadAllAsync().Result);
        }
    }
}