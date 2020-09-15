using DAL.ORM.Interfaces;
using System;

namespace DAL.ORM.Models
{
    /// <summary>Interface describes subject model</summary>
    public class Subject : ISubject
    {
        /// <summary>Default constructor</summary>
        public Subject()
        {
        }

        /// <summary>Creating an instance of <see cref="Subject"/> via name</summary>
        /// <param name="name">Subject name</param>
        public Subject(string name) => Name = name;

        /// <summary>Creating an instance of <see cref="Subject"/> via name</summary>
        /// <param name="id">Subject id</param>
        /// <param name="name">Subject name</param>
        public Subject(int id, string name) => (Id, Name) = (id, name);

        /// <inheritdoc cref="ISubject.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="ISubject.Name"/>
        public string Name { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is Subject subject && Id == subject.Id && Name == subject.Name;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Id, Name);
    }
}