namespace ResultsOfTheSession.Interfaces.Group
{
    public interface IGroup
    {
        int Id { get; set; }

        string Name { get; set; }

        int SessionInfoId { get; set; }
    }
}