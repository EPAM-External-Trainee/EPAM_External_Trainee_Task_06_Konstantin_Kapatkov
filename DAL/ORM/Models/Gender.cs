using DAL.ORM.Interfaces;
using System;

namespace DAL.ORM.Models
{
    /// <summary>Class describes gender model</summary>
    public class Gender : IGender
    {
        /// <summary>Default constructor</summary>
        public Gender()
        {
        }

        /// <summary>Creating an instance of <see cref="Gender"/> via gender type name</summary>
        /// <param name="genderType">Gender type name</param>
        public Gender(string genderType) => GenderType = genderType;

        /// <summary>Creating an instance of <see cref="Gender"/> via id and gender type name</summary>
        /// <param name="id">Gender id</param>
        /// <param name="genderType">Gender type name</param>
        public Gender(int id, string genderType) => (Id, GenderType) = (id, genderType);

        /// <inheritdoc cref=" IGender.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref=" IGender.GenderType"/>
        public string GenderType { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is Gender gender && Id == gender.Id && GenderType == gender.GenderType;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Id, GenderType);
    }
}