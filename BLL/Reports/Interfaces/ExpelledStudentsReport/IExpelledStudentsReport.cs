using BLL.Reports.Excel.Views.ExpelledStudentsReport.ReportDataViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using System;

namespace BLL.Reports.Interfaces.ExpelledStudentsReport
{
    /// <summary>Interface describing group expelled students report functionality</summary>
    public interface IExpelledStudentsReport
    {
        /// <summary>Getting report data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref=" ExpelledStudentsReportView"/> report data</returns>
        ExpelledStudentsReportView GetReport(int sessionId);

        /// <summary>Getting report data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="ExpelledStudentsTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref=" ExpelledStudentsReportView"/> ordered report data</returns>
        ExpelledStudentsReportView GetReport(int sessionId, Func<ExpelledStudentsTableRowView, object> predicate, bool isDescOrder = false);
    }
}