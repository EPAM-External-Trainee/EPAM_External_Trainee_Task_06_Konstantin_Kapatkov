using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.ReportDataViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.ExpelledStudentsReport.ReportDataViews
{
    /// <summary>Class describing the view of expelled students report</summary>
    public class ExpelledStudentsReportView : IExpelledStudentsReportView
    {
        /// <inheritdoc cref="IExpelledStudentsReportView.ExpelledStudentsTables"/>
        public IEnumerable<ExpelledStudentsTableView> ExpelledStudentsTables { get; set; }
    }
}