using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews
{
    /// <summary>Class describing the view of the expelled students table</summary>
    public class ExpelledStudentsTableView : IExpelledStudentsTableView
    {
        /// <summary>Creating an instance of <see cref="ExpelledStudentsTableView"/> via table row views and group name</summary>
        /// <param name="tableRowViews"></param>
        /// <param name="groupName"></param>
        public ExpelledStudentsTableView(IEnumerable<ExpelledStudentsTableRowView> tableRowViews, string groupName)
        {
            TableRowViews = tableRowViews;
            GroupName = groupName;
        }

        /// <inheritdoc cref="IExpelledStudentsTableView.Headers"/>
        public string[] Headers { get; } = { "Surname", "Name", "Patronymic" };

        /// <inheritdoc cref="IExpelledStudentsTableView.TableRowViews"/>
        public IEnumerable<ExpelledStudentsTableRowView> TableRowViews { get; set; }

        /// <inheritdoc cref="IExpelledStudentsTableView.GroupName"/>
        public string GroupName { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is ExpelledStudentsTableView view && Headers.SequenceEqual(view.Headers) && TableRowViews.SequenceEqual(view.TableRowViews) && GroupName == view.GroupName;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Headers, TableRowViews, GroupName);
    }
}