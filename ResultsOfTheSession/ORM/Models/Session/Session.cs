using ResultsOfTheSession.ORM.Interfaces.Session;
using System;

namespace ResultsOfTheSession.ORM.Models.Session
{
    public class Session : ISession
    {
        public Session(int id, string name, string academicYear) => (Id, Name, AcademicYear) = (id, name, academicYear);

        public Session(string name, string academicYear) => (Name, AcademicYear) = (name, academicYear);

        public int Id { get; set; }

        public string Name { get; set; }

        public string AcademicYear { get; set; }

        public override bool Equals(object obj) => obj is Session session && Id == session.Id && Name == session.Name && AcademicYear == session.AcademicYear;

        public override int GetHashCode() => HashCode.Combine(Id, Name, AcademicYear);

        public override string ToString() => $"{Name}, academic year: {AcademicYear}";
    }
}