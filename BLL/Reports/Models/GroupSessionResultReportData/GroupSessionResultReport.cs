using BLL.Reports.Excel.Views.GroupSessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRowViews;
using BLL.Reports.Interfaces.GroupSessionResultReport;
using BLL.Reports.Models.GroupSessionResultReportData.Tables;
using System;

namespace BLL.Reports.Models.GroupSessionResultReportData
{
    /// <summary>Class describing group session result report functionality</summary>
    public class GroupSessionResultReport : IGroupSessionResultReport
    {
        /// <summary>Group session result table</summary>
        private IGroupSessionResultTable GroupSessionResultTable { get; }

        /// <summary>Creating an instance of <see cref="GroupSessionResultReport"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public GroupSessionResultReport(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;")
        {
            GroupSessionResultTable = new GroupSessionResultTable(connectionString);
        }

        /// <inheritdoc cref="IGroupSessionResultReport.GetReport"/>
        public GroupSessionResultReportView GetReport()
        {
            return new GroupSessionResultReportView
            {
                GroupSessionResultTables = GroupSessionResultTable.GetGroupSessionResultTables()
            };
        }

        /// <inheritdoc cref="IGroupSessionResultReport.GetReport(Func{GroupSessionResultTableRowView, object}, bool)/>
        public GroupSessionResultReportView GetReport(Func<GroupSessionResultTableRowView, object> predicate, bool isDescOrder = false)
        {
            return new GroupSessionResultReportView
            {
                GroupSessionResultTables = GroupSessionResultTable.GetGroupSessionResultTables(predicate, isDescOrder),
            };
        }
    }
}