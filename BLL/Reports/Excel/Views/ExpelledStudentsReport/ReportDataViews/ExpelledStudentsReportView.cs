using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.ReportDataViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.ExpelledStudentsReport.ReportDataViews
{
    public class ExpelledStudentsReportView : IExpelledStudentsReportView
    {
        public IEnumerable<ExpelledStudentsTableView> ExpelledStudentsTables { get; set; }
    }
}