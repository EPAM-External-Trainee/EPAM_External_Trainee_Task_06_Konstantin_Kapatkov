using BLL.Reports.Excel.Views.ExpelledStudentsReport.ReportDataViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using BLL.Reports.Models.ExpelledStudentTable.Tables;
using System;

namespace BLL.Reports.Models.ExpelledStudentsReport
{
    public class ExpelledStudentsReport
    {    
        private ExpelledStudentsTable ExpelledStudentsTable { get; }

        public ExpelledStudentsReport(string connetionString)
        {
            ExpelledStudentsTable = new ExpelledStudentsTable(connetionString);
        }

        public ExpelledStudentsReportView GetReport(int sessionId)
        {
            return new ExpelledStudentsReportView { ExpelledStudentsTables = ExpelledStudentsTable.GetReportData(sessionId) };
        }

        public ExpelledStudentsReportView GetReport(int sessionId, Func<ExpelledStudentsTableRowView, object> predicate, bool isDescOrder = false)
        {
            return new ExpelledStudentsReportView { ExpelledStudentsTables = ExpelledStudentsTable.GetReportData(sessionId, predicate, isDescOrder) };
        }
    }
}