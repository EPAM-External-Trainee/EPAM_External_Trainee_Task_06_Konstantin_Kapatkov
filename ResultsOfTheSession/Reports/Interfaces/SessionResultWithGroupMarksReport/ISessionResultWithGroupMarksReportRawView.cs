namespace ResultsOfTheSession.PreparationOfReports.Interfaces
{
    public interface ISessionResultWithGroupMarksReportRawView
    {
        string GroupName { get; set; }

        double MaxAssessment { get; set; }

        double MinAssessment { get; set; }

        double AvgAssessment { get; set; }
    }
}