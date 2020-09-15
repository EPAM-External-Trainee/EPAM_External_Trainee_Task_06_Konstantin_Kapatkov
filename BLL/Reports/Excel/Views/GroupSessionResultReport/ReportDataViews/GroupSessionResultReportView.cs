using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.GroupSessionResultReport.ReportDataViews
{
    /// <summary>Class describing the view of group session result report</summary>
    public class GroupSessionResultReportView : IGroupSessionResultReportView
    {
        /// <inheritdoc cref="IGroupSessionResultReportView.GroupSessionResultTables"/>
        public IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }
    }
}