using BLL.Reports.Excel.Views.SessionResultReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.ReportDataViews
{
    /// <summary>Interface describing the view of session result report</summary>
    public interface ISessionResultReportView
    {
        /// <summary><see cref="GroupTableView"/> objects as group tables</summary>
        IEnumerable<GroupTableView> GroupTables { get; set; }
    }
}