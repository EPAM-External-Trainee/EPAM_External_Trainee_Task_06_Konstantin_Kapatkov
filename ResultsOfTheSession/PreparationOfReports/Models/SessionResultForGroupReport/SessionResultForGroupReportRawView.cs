using ResultsOfTheSession.PreparationOfReports.Interfaces;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport
{
    public class SessionResultForGroupReportRawView : ISessionResultForGroupReportRawView
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Subject { get; set; }

        public string Type { get; set; }

        public string Date { get; set; }

        public string Assessment { get; set; }
    }
}