using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Excel.Views.GroupSessionResultReport.ReportDataViews
{
    /// <summary>Class describing the view of group session result report</summary>
    public class GroupSessionResultReportView : IGroupSessionResultReportView
    {
        /// <inheritdoc cref="IGroupSessionResultReportView.GroupSessionResultTables"/>
        public IEnumerable<GroupSessionResultTableView> GroupSessionResultTables { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is GroupSessionResultReportView view && GroupSessionResultTables.SequenceEqual(view.GroupSessionResultTables);

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(GroupSessionResultTables);
    }
}