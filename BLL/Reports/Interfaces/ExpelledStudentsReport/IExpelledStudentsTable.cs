using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using System;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.ExpelledStudentsReport
{
    /// <summary>Interface describing expelled students table functionality</summary>
    public interface IExpelledStudentsTable
    {
        /// <summary>Getting group session result table data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="ExpelledStudentsTableView"/> table data</returns>
        IEnumerable<ExpelledStudentsTableView> GetReportData(int sessionId);

        /// <summary>Getting group session result table data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="ExpelledStudentsTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="ExpelledStudentsTableView"/> ordered table data</returns>
        IEnumerable<ExpelledStudentsTableView> GetReportData(int sessionId, Func<ExpelledStudentsTableRowView, object> predicate, bool isDescOrder = false);
    }
}