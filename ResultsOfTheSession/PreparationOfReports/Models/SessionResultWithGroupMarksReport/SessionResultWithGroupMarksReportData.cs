using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport
{
    public class SessionResultWithGroupMarksReportData
    {
        public List<SessionResultWithGroupMarksReportRawView> PrepareSessionResultWithGroupMarksRowViews { get; set; }

        public string SessionName { get; set; }

        public string AcademicYear { get; set; }

        public string[] Headers { get; set; } = { "Group name", "Max assessment", "Min assessment", "Average assessment" };
    }
}