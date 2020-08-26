using ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Interfaces.ExpelledStudentsReport
{
    public interface IExpelledStudentsReportData
    {
        IEnumerable<ExpelledStudentsReportRawView> ExpelledStudentsReportRawViews { get; set; }

        string AcademicYear { get; set; }

        string GroupName { get; set; }

        string[] Headers { get; set; }
    }
}