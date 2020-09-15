using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.ReportDataViews
{
    /// <summary>Interface describing the view of expelled students report</summary>
    public interface IExpelledStudentsReportView
    {
        /// <summary><see cref="ExpelledStudentsTableView"/> objects as group session result tables</summary>
        public IEnumerable<ExpelledStudentsTableView> ExpelledStudentsTables { get; set; }
    }
}