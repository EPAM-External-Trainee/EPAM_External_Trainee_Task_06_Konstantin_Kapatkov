namespace ResultsOfTheSession.PreparationOfReports.Interfaces
{
    public interface ISessionResultForGroupReportRawView
    {
        string Surname { get; set; }

        string Name { get; set; }

        string Patronymic { get; set; }

        string Subject { get; set; }

        string Type { get; set; }

        string Date { get; set; }

        string Assessment { get; set; }
    }
}