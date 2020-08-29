using ResultsOfTheSession.ORM.Interfaces;
using System;

namespace ResultsOfTheSession.ORM.Models
{
    public class Student : IStudent
    {
        public Student(string name, string surname, string patronymic, int genderId, DateTime birthday, int groupId) => (Name, Surname, Patronymic, GenderId, Birthday, GroupId) = (name, surname, patronymic, genderId, birthday, groupId);

        public Student(int id, string name, string surname, string patronymic, int genderId, DateTime birthday, int groupId) => (Id, Name, Surname, Patronymic, GenderId, Birthday, GroupId) = (id, name, surname, patronymic, genderId, birthday, groupId);

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public int GenderId { get; set; }

        public int GroupId { get; set; }

        public override bool Equals(object obj) => obj is Student student && Id == student.Id && Name == student.Name && Surname == student.Surname && Patronymic == student.Patronymic && GenderId == student.GenderId && Birthday == student.Birthday && GroupId == student.GroupId;

        public override int GetHashCode() => HashCode.Combine(Id, Name, Surname, Patronymic, GenderId, Birthday, GroupId);

        public override string ToString() => $"Student id: {Id}, name: {Name}, surname: {Surname}, patronymic: {Patronymic}, gender id: {GenderId}, birthday: {Birthday.ToShortDateString()}, group id: {GroupId}.";
    }
}