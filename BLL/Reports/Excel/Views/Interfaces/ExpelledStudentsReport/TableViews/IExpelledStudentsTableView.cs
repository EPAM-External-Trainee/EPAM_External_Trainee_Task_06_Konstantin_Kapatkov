using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableViews
{
    /// <summary>Interface describing the view of the expelled students table</summary>
    public interface IExpelledStudentsTableView
    {
        /// <summary>Table headers</summary>
        string[] Headers { get; }

        /// <summary><see cref="ExpelledStudentsTableRowView"/> objects as row views</summary>
        IEnumerable<ExpelledStudentsTableRowView> TableRowViews { get; set; }

        /// <summary>Group name</summary>
        string GroupName { get; set; }
    }
}