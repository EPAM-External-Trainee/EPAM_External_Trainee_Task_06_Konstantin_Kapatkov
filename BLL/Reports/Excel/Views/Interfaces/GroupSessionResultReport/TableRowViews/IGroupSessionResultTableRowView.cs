namespace BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport
{
    /// <summary>Interface describing the row view of the group session result table</summary>
    public interface IGroupSessionResultTableRowView
    {
        /// <summary>Group name</summary>
        string GroupName { get; set; }

        /// <summary>Maximum assessment</summary>
        double MaxAssessment { get; set; }

        /// <summary>Minimum assessment</summary>
        double MinAssessment { get; set; }

        /// <summary>Average assessment</summary>
        double AvgAssessment { get; set; }
    }
}