using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.ReportDataViews;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Excel.Views.ExpelledStudentsReport.ReportDataViews
{
    /// <summary>Class describing the view of expelled students report</summary>
    public class ExpelledStudentsReportView : IExpelledStudentsReportView
    {
        /// <inheritdoc cref="IExpelledStudentsReportView.ExpelledStudentsTables"/>
        public IEnumerable<ExpelledStudentsTableView> ExpelledStudentsTables { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is ExpelledStudentsReportView view && ExpelledStudentsTables.SequenceEqual(view.ExpelledStudentsTables);

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(ExpelledStudentsTables);
    }
}