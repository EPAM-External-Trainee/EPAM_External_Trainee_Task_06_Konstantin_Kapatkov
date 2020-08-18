using ResultsOfTheSession.Enums;
using System;

namespace ResultsOfTheSession.Interfaces
{
    public interface IStudent
    {
        int Id { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        string Patronymic { get; set; }

        Gender Gender { get; set; }

        DateTime Birthday { get; set; }

        int GroupID { get; set; }
    }
}