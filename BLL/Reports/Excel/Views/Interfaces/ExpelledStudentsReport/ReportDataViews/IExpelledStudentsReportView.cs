using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.ReportDataViews
{
    public interface IExpelledStudentsReportView
    {
        public IEnumerable<ExpelledStudentsTableView> ExpelledStudentsTables { get; set; }
    }
}