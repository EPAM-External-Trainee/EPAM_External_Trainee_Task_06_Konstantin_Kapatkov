using System;

namespace ResultsOfTheSession.ORM.Interfaces
{
    public interface IStudent
    {
        int Id { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        string Patronymic { get; set; }

        int GenderId { get; set; }

        DateTime Birthday { get; set; }

        int GroupId { get; set; }
    }
}