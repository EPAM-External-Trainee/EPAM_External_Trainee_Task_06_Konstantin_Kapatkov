using ResultsOfTheSession.PreparationOfReports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport
{
    public struct SessionResultReportData : ISessionResultReportData
    {
        public SessionResultReportData(IEnumerable<SessionResultReportRawView> sessionResultForGroupRawViews, string sessionInfo, string groupName)
        {
            SessionResultReportRawViews = sessionResultForGroupRawViews;
            SessionInfo = sessionInfo;
            GroupName = groupName;
            Headers = new string[] { "Surname", "Name", "Patronymic", "Subject", "Form", "Date", "Assessment" };
        }

        public IEnumerable<SessionResultReportRawView> SessionResultReportRawViews { get; set; }

        public string SessionInfo { get; set; }

        public string GroupName { get; set; }

        public string[] Headers { get; set; }

        public override bool Equals(object obj) => obj is SessionResultReportData data && SessionResultReportRawViews.SequenceEqual(data.SessionResultReportRawViews) && SessionInfo == data.SessionInfo && GroupName == data.GroupName && Headers.SequenceEqual(data.Headers);

        public override int GetHashCode() => HashCode.Combine(SessionResultReportRawViews, SessionInfo, GroupName, Headers);
    }
}