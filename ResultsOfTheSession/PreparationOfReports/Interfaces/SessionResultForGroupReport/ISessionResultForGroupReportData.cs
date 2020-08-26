using ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Interfaces
{
    public interface ISessionResultForGroupReportData
    {
        IEnumerable<SessionResultForGroupReportRawView> SessionResultForGroupRawViews { get; set; }

        string SessionInfo { get; set; }

        string GroupName { get; set; }

        string[] Headers { get; set; }
    }
}