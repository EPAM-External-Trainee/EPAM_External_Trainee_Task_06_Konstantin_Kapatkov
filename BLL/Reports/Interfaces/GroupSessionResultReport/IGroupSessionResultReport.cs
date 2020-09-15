using BLL.Reports.Excel.Views.GroupSessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRowViews;
using System;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    /// <summary>Interface describing group session result report functionality</summary>
    public interface IGroupSessionResultReport
    {
        /// <summary>Getting report data</summary>
        /// <returns><see cref="GroupSessionResultReportView"/> report data</returns>
        GroupSessionResultReportView GetReport();

        /// <summary>Getting report data</summary>
        /// <param name="predicate"><see cref="GroupSessionResultTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="GroupSessionResultReportView"/> ordered report data</returns>
        GroupSessionResultReportView GetReport(Func<GroupSessionResultTableRowView, object> predicate, bool isDescOrder);
    }
}