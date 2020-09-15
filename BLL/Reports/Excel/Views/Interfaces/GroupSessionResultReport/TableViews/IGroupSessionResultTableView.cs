using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRowViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews
{
    /// <summary>Interface describing the view of the group session result table</summary>
    public interface IGroupSessionResultTableView
    {
        /// <summary>Table Headers</summary>
        string[] Headers { get; }

        /// <summary><see cref="GroupSessionResultTableRowView"/> objects as row views</summary>
        IEnumerable<GroupSessionResultTableRowView> TableRowViews { get; set; }

        /// <summary>Session name</summary>
        string SessionName { get; set; }

        /// <summary>Academic year</summary>
        /// <example>2020</example>
        /// <example>2019/2020</example>
        string AcademicYear { get; set; }
    }
}