using BLL.Reports.Excel.Views.SessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.SessionResultReport.TableRowViews;
using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Models.SessionResultReportData.Tables;
using System;

namespace BLL.Reports.Models.SessionResultReportData
{
    /// <summary>Class describing session result report functionality</summary>
    public class SessionResultReport : ISessionResultReport
    {
        /// <summary>Group table</summary>
        private readonly IGroupTable _groupTable;

        /// <summary>Creating an instance of <see cref="SessionResultReport"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public SessionResultReport(string connectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;")
        {
            _groupTable = new GroupTable(connectionString);
        }

        /// <inheritdoc cref="ISessionResultReport.GetReport(int)"/>
        public SessionResultReportView GetReport(int sessionId)
        {
            return new SessionResultReportView
            {
                GroupTables = _groupTable.GetGroupTableData(sessionId),
            };
        }

        /// <inheritdoc cref="ISessionResultReport.GetReport(int, Func{GroupTableRowView, object}, bool)"/>
        public SessionResultReportView GetReport(int sessionId, Func<GroupTableRowView, object> predicate, bool isDescOrder)
        {
            return new SessionResultReportView
            {
                GroupTables = _groupTable.GetGroupTableData(sessionId, predicate, isDescOrder)
            };
        }
    }
}