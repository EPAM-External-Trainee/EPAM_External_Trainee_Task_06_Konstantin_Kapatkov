namespace ResultsOfTheSession.ORM.Interfaces.Session
{
    public interface ISessionResult
    {
        int Id { get; set; }

        int SubjectId { get; set; }

        int StudentId { get; set; }

        string Assessment { get; set; }
    }
}