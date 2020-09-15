using DAL.ORM.Interfaces;
using System;

namespace DAL.ORM.Models
{
    /// <summary>Class describes group model</summary>
    public class Group : IGroup
    {
        /// <summary>Default constructor</summary>
        public Group()
        {
        }

        /// <summary>Creating an instance of <see cref="Group"/> via name</summary>
        /// <param name="name">Group name</param>
        public Group(string name) => Name = name;

        /// <summary>Creating an instance of <see cref="Group"/> via id, name and group specialty id</summary>
        /// <param name="id">Group id</param>
        /// <param name="name">Group name</param>
        public Group(int id, string name) => (Id, Name) = (id, name);

        /// <inheritdoc cref="IGroup.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="IGroup.Name"/>
        public string Name { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is Group group && Id == group.Id && Name == group.Name;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Id, Name);
    }
}