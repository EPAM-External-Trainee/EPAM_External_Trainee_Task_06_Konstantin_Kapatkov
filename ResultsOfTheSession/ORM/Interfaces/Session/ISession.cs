namespace ResultsOfTheSession.ORM.Interfaces.Session
{
    public interface ISession
    {
        int Id { get; set; }

        string Name { get; set; }

        string AcademicYear { get; set; }
    }
}