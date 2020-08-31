using ResultsOfTheSession.PreparationOfReports.Interfaces.SessionResultWithGroupMarks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport
{
    public struct GroupSessionResultReportData : IGroupSessionResultReportData
    {
        public GroupSessionResultReportData(IEnumerable<GroupSessionResultReportRawView> sessionResultWithGroupMarksRowViews, string sessionName, string academicYear)
        {
            GroupSessionResultReportRowViews = sessionResultWithGroupMarksRowViews;
            SessionName = sessionName;
            AcademicYear = academicYear;
            Headers = new string[] { "Group name", "Max assessment", "Min assessment", "Average assessment" };
        }

        public IEnumerable<GroupSessionResultReportRawView> GroupSessionResultReportRowViews { get; set; }

        public string SessionName { get; set; }

        public string AcademicYear { get; set; }

        public string[] Headers { get; set; }

        public override bool Equals(object obj) => obj is GroupSessionResultReportData data && GroupSessionResultReportRowViews.SequenceEqual(data.GroupSessionResultReportRowViews) && SessionName == data.SessionName && AcademicYear == data.AcademicYear && Headers.SequenceEqual(data.Headers);

        public override int GetHashCode() => HashCode.Combine(GroupSessionResultReportRowViews, SessionName, AcademicYear, Headers);
    }
}