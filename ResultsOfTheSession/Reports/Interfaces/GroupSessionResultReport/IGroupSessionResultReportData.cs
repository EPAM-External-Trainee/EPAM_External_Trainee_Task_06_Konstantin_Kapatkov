using ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Interfaces.SessionResultWithGroupMarks
{
    public interface IGroupSessionResultReportData
    {
        IEnumerable<GroupSessionResultReportRawView> SessionResultWithGroupMarksRowViews { get; set; }

        string SessionName { get; set; }

        string AcademicYear { get; set; }

        string[] Headers { get; set; }
    }
}