using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRowViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using System;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.GroupSessionResultReport
{
    /// <summary>Interface describing group session result table functionality</summary>
    public interface IGroupSessionResultTable
    {
        /// <summary>Getting group session result table data</summary>
        /// <returns><see cref="GroupSessionResultTableView"/> table data</returns>
        IEnumerable<GroupSessionResultTableView> GetGroupSessionResultTables();

        /// <summary>Getting group session result table data</summary>
        /// <param name="predicate"><see cref="GroupSessionResultTableRowView"/> column to sort the selection by</param>
        /// <param name="isDescOrder">Is descending order</param>
        /// <returns><see cref="GroupSessionResultTableView"/>ordered table data</returns>
        IEnumerable<GroupSessionResultTableView> GetGroupSessionResultTables(Func<GroupSessionResultTableRowView, object> predicate, bool isDescOrder = false);
    }
}