using BLL.Reports.Excel.Views.SessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.SessionResultReport.TableRowViews;
using System;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    /// <summary>Interface describing session result report functionality</summary>
    public interface ISessionResultReport
    {
        /// <summary>Getting report data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="SessionResultReportView"/> report data</returns>
        SessionResultReportView GetReport(int sessionId);

        /// <summary>Getting report data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="GroupTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="SessionResultReportView"/> ordered report data</returns>
        SessionResultReportView GetReport(int sessionId, Func<GroupTableRowView, object> predicate, bool isDescOrder);
    }
}