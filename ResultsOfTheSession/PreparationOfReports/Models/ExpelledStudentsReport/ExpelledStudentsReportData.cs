using ResultsOfTheSession.PreparationOfReports.Interfaces.ExpelledStudentsReport;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport
{
    public class ExpelledStudentsReportData : IExpelledStudentsReportData
    {
        public IEnumerable<ExpelledStudentsReportRawView> ExpelledStudentsReportRawViews { get; set; }

        public string AcademicYear { get; set; }

        public string GroupName { get; set; }

        public string[] Headers { get; set; } = { "Surname", "Name", "Patronymic" };
    }
}