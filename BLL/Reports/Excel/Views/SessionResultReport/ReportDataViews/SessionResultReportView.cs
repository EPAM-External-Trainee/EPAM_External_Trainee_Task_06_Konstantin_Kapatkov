using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.SessionResultReport.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Excel.Views.SessionResultReport.ReportDataViews
{
    /// <summary>Class describing the view of session result report</summary>
    public class SessionResultReportView : ISessionResultReportView
    {
        /// <inheritdoc cref="ISessionResultReportView.GroupTables"/>
        public IEnumerable<GroupTableView> GroupTables { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is SessionResultReportView view && GroupTables.SequenceEqual(view.GroupTables);

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(GroupTables);
    }
}