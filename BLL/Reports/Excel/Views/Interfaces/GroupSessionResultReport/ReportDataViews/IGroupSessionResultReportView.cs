using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.ReportDataViews
{
    /// <summary>Interface describing the view of group session result report</summary>
    public interface IGroupSessionResultReportView
    {
        /// <summary><see cref="GroupSessionResultTableView"/> objects as group session result tables</summary>
        IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }
    }
}