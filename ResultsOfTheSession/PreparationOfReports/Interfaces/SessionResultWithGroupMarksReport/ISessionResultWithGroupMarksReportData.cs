using ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Interfaces.SessionResultWithGroupMarks
{
    public interface ISessionResultWithGroupMarksReportData
    {
        List<SessionResultWithGroupMarksReportRawView> PrepareSessionResultWithGroupMarksRowViews { get; set; }

        string SessionInfo { get; set; }

        string[] Headers { get; set; }
    }
}