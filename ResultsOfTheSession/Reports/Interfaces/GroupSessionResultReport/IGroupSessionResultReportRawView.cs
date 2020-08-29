namespace ResultsOfTheSession.PreparationOfReports.Interfaces
{
    public interface IGroupSessionResultReportRawView
    {
        string GroupName { get; set; }

        double MaxAssessment { get; set; }

        double MinAssessment { get; set; }

        double AvgAssessment { get; set; }
    }
}