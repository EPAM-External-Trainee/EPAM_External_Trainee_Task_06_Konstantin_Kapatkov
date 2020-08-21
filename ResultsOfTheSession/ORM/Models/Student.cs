using ResultsOfTheSession.ORM.Interfaces;
using System;

namespace ResultsOfTheSession.ORM.Models
{
    public class Student : IStudent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public int GenderId { get; set; }

        public DateTime Birthday { get; set; }

        public int GroupId { get; set; }
    }
}