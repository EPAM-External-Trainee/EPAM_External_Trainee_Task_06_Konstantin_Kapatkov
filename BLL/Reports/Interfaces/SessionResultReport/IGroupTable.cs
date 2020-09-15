using BLL.Reports.Excel.Views.SessionResultReport.TableRowViews;
using BLL.Reports.Excel.Views.SessionResultReport.TableViews;
using System;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.SessionResultReport
{
    /// <summary>Interface describing group table functionality</summary>
    public interface IGroupTable
    {
        /// <summary>Getting group table data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="IEnumerable{GroupTableView}"/> tables data</returns>
        IEnumerable<GroupTableView> GetGroupTableData(int sessionId);

        /// <summary>Getting group table data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="predicate"><see cref="GroupTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="IEnumerable{GroupTableView}"/> ordered tables data</returns>
        IEnumerable<GroupTableView> GetGroupTableData(int sessionId, Func<GroupTableRowView, object> predicate, bool isDescOrder);
    }
}