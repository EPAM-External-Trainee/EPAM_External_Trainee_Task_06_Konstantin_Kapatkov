using ResultsOfTheSession.PreparationOfReports.Interfaces;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport
{
    public class SessionResultForGroupReportData : ISessionResultForGroupReportData
    {
        public List<SessionResultForGroupReportRawView> SessionResultForGroupRawViews { get; set; }

        public string SessionInfo { get; set; }

        public string GroupName { get; set; }

        public string[] Headers { get; set; } = { "Surname", "Name", "Patronymic", "Subject", "Form", "Date", "Assessment" };
    }
}