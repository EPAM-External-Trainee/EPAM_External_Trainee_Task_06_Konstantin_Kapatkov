using ResultsOfTheSession.ORM.Interfaces;
using System;

namespace ResultsOfTheSession.ORM.Models
{
    public class Gender : IGender
    {
        public Gender(int id, string gednerType) => (Id, GenderType) = (id, gednerType);

        public Gender(string gednerType) => GenderType = gednerType;

        public int Id { get; set; }

        public string GenderType { get; set; }

        public override bool Equals(object obj) => obj is Gender gender && Id == gender.Id && GenderType == gender.GenderType;

        public override int GetHashCode() => HashCode.Combine(Id, GenderType);

        public override string ToString() => $"Gender id: {Id}, gender type: {GenderType}.";
    }
}