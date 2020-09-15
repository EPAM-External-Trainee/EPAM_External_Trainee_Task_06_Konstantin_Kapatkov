using BLL.Reports.Excel.Views.ExpelledStudentsReport.ReportDataViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using System;

namespace BLL.Reports.Interfaces.ExpelledStudentsReport
{
    public interface IExpelledStudentsReport
    {
        ExpelledStudentsReportView GetReport(int sessionId);

        ExpelledStudentsReportView GetReport(int sessionId, Func<ExpelledStudentsTableRowView, object> predicate, bool isDescOrder = false);
    }
}