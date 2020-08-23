using ResultsOfTheSession.ORM.Interfaces;
using System;

namespace ResultsOfTheSession.ORM.Models
{
    public class Group : IGroup
    {
        public Group(int id, string name) => (Id, Name) = (id, name);

        public Group(string name) => Name = name;

        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj) => obj is Group group && Id == group.Id && Name == group.Name;

        public override int GetHashCode() => HashCode.Combine(Id, Name);

        public override string ToString() => $"Group id: {Id}, group name: {Name}.";
    }
}