using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using System;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces.ExpelledStudentsReport
{
    public interface IExpelledStudentsTable
    {
        IEnumerable<ExpelledStudentsTableView> GetReportData(int sessionId);

        IEnumerable<ExpelledStudentsTableView> GetReportData(int sessionId, Func<ExpelledStudentsTableRowView, object> predicate, bool isDescOrder = false);
    }
}