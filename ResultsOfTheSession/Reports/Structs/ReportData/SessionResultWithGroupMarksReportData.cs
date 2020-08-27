using ResultsOfTheSession.PreparationOfReports.Interfaces.SessionResultWithGroupMarks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport
{
    public struct SessionResultWithGroupMarksReportData : ISessionResultWithGroupMarksReportData
    {
        public SessionResultWithGroupMarksReportData(IEnumerable<SessionResultWithGroupMarksReportRawView> sessionResultWithGroupMarksRowViews, string sessionName, string academicYear)
        {
            SessionResultWithGroupMarksRowViews = sessionResultWithGroupMarksRowViews;
            SessionName = sessionName;
            AcademicYear = academicYear;
            Headers = new string[] { "Group name", "Max assessment", "Min assessment", "Average assessment" };
        }

        public IEnumerable<SessionResultWithGroupMarksReportRawView> SessionResultWithGroupMarksRowViews { get; set; }

        public string SessionName { get; set; }

        public string AcademicYear { get; set; }

        public string[] Headers { get; set; }

        public override bool Equals(object obj) => obj is SessionResultWithGroupMarksReportData data && SessionResultWithGroupMarksRowViews.SequenceEqual(data.SessionResultWithGroupMarksRowViews) && SessionName == data.SessionName && AcademicYear == data.AcademicYear && Headers.SequenceEqual(data.Headers);

        public override int GetHashCode() => HashCode.Combine(SessionResultWithGroupMarksRowViews, SessionName, AcademicYear, Headers);
    }
}