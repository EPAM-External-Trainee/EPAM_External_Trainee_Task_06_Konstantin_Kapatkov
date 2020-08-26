using ResultsOfTheSession.PreparationOfReports.Interfaces;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport
{
    public class SessionResultWithGroupMarksReportRawView : ISessionResultWithGroupMarksReportRawView
    {
        public string GroupName { get; set; }

        public double MaxAssessment { get; set; }

        public double MinAssessment { get; set; }

        public double AvgAssessment { get; set; }
    }
}