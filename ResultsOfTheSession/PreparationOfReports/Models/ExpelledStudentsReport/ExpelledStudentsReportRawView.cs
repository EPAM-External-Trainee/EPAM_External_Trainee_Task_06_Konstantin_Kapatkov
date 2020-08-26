using ResultsOfTheSession.PreparationOfReports.Interfaces.ExpelledStudentsReport;

namespace ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport
{
    public class ExpelledStudentsReportRawView : IExpelledStudentsReportRowView
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }
    }
}