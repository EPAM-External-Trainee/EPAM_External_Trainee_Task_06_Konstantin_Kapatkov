using ResultsOfTheSession.ORM.Interfaces;
using System;

namespace ResultsOfTheSession.ORM.Models
{
    public class Subject : ISubject
    {
        public Subject(string name) => Name = name;

        public Subject(int id, string name) => (Id, Name) = (id, name);

        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj) => obj is Subject subject && Id == subject.Id && Name == subject.Name;

        public override int GetHashCode() => HashCode.Combine(Id, Name);

        public override string ToString() => $"Subject id: {Id}, subject name: {Name}.";
    }
}