using System;

namespace ResultsOfTheSession.Interfaces
{
    public interface ISessionInfo
    {
        int Id { get; set; }

        DateTime StartDateOfTheSession { get; set; }

        DateTime EndDateOfTheSession { get; set; }
    }
}