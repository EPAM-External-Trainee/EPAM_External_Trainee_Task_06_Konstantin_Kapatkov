using ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Interfaces
{
    public interface ISessionResultReportData
    {
        IEnumerable<SessionResultReportRawView> SessionResultForGroupRawViews { get; set; }

        string SessionInfo { get; set; }

        string GroupName { get; set; }

        string[] Headers { get; set; }
    }
}