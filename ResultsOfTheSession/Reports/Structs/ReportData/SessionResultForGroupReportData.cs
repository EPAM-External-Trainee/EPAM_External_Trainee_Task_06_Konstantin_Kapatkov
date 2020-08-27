using ResultsOfTheSession.PreparationOfReports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport
{
    public struct SessionResultForGroupReportData : ISessionResultForGroupReportData
    {
        public SessionResultForGroupReportData(IEnumerable<SessionResultForGroupReportRawView> sessionResultForGroupRawViews, string sessionInfo, string groupName, string[] headers)
        {
            SessionResultForGroupRawViews = sessionResultForGroupRawViews;
            SessionInfo = sessionInfo;
            GroupName = groupName;
            Headers = headers;
        }

        public IEnumerable<SessionResultForGroupReportRawView> SessionResultForGroupRawViews { get; set; }

        public string SessionInfo { get; set; }

        public string GroupName { get; set; }

        public string[] Headers { get; set; }

        public override bool Equals(object obj) => obj is SessionResultForGroupReportData data && SessionResultForGroupRawViews.SequenceEqual(data.SessionResultForGroupRawViews) && SessionInfo == data.SessionInfo && GroupName == data.GroupName && Headers.SequenceEqual(data.Headers);

        public override int GetHashCode() => HashCode.Combine(SessionResultForGroupRawViews, SessionInfo, GroupName, Headers);
    }
}