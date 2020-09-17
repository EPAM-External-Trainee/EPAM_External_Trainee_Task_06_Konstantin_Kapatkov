using BLL.Reports.Excel.Views.ExpelledStudentsReport.ReportDataViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using BLL.Reports.Interfaces.ExpelledStudentsReport;
using BLL.Reports.Models.ExpelledStudentTable.Tables;
using System;

namespace BLL.Reports.Models.ExpelledStudentsReport
{
    /// <summary>Class describing expelled students report functionality</summary>
    public class ExpelledStudentsReport : IExpelledStudentsReport
    {
        /// <summary>Expelled students table</summary>
        private readonly IExpelledStudentsTable _expelledStudentsTable;

        /// <summary>Creating an instance of <see cref="ExpelledStudentsReport"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public ExpelledStudentsReport(string connectionString)
        {
            _expelledStudentsTable = new ExpelledStudentsTable(connectionString);
        }

        /// <inheritdoc cref="IExpelledStudentsReport.GetReport(int)"/>
        public ExpelledStudentsReportView GetReport(int sessionId) => new ExpelledStudentsReportView { ExpelledStudentsTables = _expelledStudentsTable.GetReportData(sessionId) };

        /// <inheritdoc cref="IExpelledStudentsReport.GetReport(int, Func{ExpelledStudentsTableRowView, object}, bool)"/>
        public ExpelledStudentsReportView GetReport(int sessionId, Func<ExpelledStudentsTableRowView, object> predicate, bool isDescOrder = false) => new ExpelledStudentsReportView { ExpelledStudentsTables = _expelledStudentsTable.GetReportData(sessionId, predicate, isDescOrder) };
    }
}