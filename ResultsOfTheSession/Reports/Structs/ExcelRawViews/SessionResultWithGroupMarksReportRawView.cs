using ResultsOfTheSession.PreparationOfReports.Interfaces;
using System;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport
{
    public struct SessionResultWithGroupMarksReportRawView : ISessionResultWithGroupMarksReportRawView
    {
        public SessionResultWithGroupMarksReportRawView(string groupName, double maxAssessment, double minAssessment, double avgAssessment)
        {
            GroupName = groupName;
            MaxAssessment = maxAssessment;
            MinAssessment = minAssessment;
            AvgAssessment = avgAssessment;
        }

        public string GroupName { get; set; }

        public double MaxAssessment { get; set; }

        public double MinAssessment { get; set; }

        public double AvgAssessment { get; set; }

        public override bool Equals(object obj) => obj is SessionResultWithGroupMarksReportRawView view && GroupName == view.GroupName && MaxAssessment == view.MaxAssessment && MinAssessment == view.MinAssessment && AvgAssessment == view.AvgAssessment;

        public override int GetHashCode() => HashCode.Combine(GroupName, MaxAssessment, MinAssessment, AvgAssessment);
    }
}