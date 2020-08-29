using NUnit.Framework;
using ResultsOfTheSession.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest.DAONUnitTest.DAOStudentNUnitTest
{
    [TestFixture]
    public class DAOStudentNUnitTests : DAOTest
    {
        [TestCase("Stepan", "Stepanov", "Stepanovich", 2001, 12, 12, 2, 2)]
        public void CreateStudent_Test(string name, string surname, string patronymic, int year, int month, int day, int genderId, int groupId)
        {
            Student student = new Student(name, surname, patronymic, genderId, new DateTime(year, month, day), groupId);
            bool result = Task.Run(async () => await DaoFactoryTest.GetStudent().CreateAsync(student).ConfigureAwait(false)).Result;
            Student expectedStudent = Task.Run(async () => await DaoFactoryTest.GetStudent().ReadAllAsync().ConfigureAwait(false)).Result.Last();
            Assert.IsTrue(result && student.Name == expectedStudent.Name && student.Surname == expectedStudent.Surname && student.Patronymic == expectedStudent.Patronymic && student.Birthday == expectedStudent.Birthday && student.GenderId == expectedStudent.GenderId && student.GroupId == expectedStudent.GroupId);
        }

        [TestCase(2, "Petya", "Pyatov", "Petrovich", 2005, 01, 05, 1, 2)]
        public void ReadStudent(int id, string name, string surname, string patronymic, int year, int month, int day, int genderId, int groupId)
        {
            Student student = Task.Run(async () => await DaoFactoryTest.GetStudent().ReadAsync(id).ConfigureAwait(false)).Result;
            Assert.AreEqual(student, new Student(id, name, surname, patronymic, genderId, new DateTime(year, month, day), groupId));
        }

        [TestCase(3, "Stepan", "Stepanov", "Stepanovich", 2001, 12, 12, 1, 2)]
        public void UpdateStudent_Test(int id, string name, string surname, string patronymic, int year, int month, int day, int genderId, int groupId)
        {
            Student student = new Student(id, name, surname, patronymic, genderId, new DateTime(year, month, day), groupId);
            bool result = Task.Run(async () => await DaoFactoryTest.GetStudent().UpdateAsync(student).ConfigureAwait(false)).Result;
            Assert.AreEqual(student, Task.Run(async () => await DaoFactoryTest.GetStudent().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [TestCase(4)]
        public void DeleteStudent_Test(int id)
        {
            bool result = Task.Run(async () => await DaoFactoryTest.GetStudent().DeleteAsync(id).ConfigureAwait(false)).Result;
            Assert.IsNull(Task.Run(async () => await DaoFactoryTest.GetStudent().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadAllStudent_Test()
        {
            IEnumerable<Student> result = Task.Run(async () => await DaoFactoryTest.GetStudent().ReadAllAsync().ConfigureAwait(false)).Result;
            Assert.IsTrue(result != null && result.Count() != 0);
        }
    }
}