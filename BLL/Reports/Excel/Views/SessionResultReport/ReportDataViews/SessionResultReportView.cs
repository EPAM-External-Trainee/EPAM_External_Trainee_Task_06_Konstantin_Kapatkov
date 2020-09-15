using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.SessionResultReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.SessionResultReport.ReportDataViews
{
    /// <summary>Class describing the view of session result report</summary>
    public class SessionResultReportView : ISessionResultReportView
    {
        /// <inheritdoc cref="ISessionResultReportView.GroupTables"/>
        public IEnumerable<GroupTableView> GroupTables { get; set; }
    }
}