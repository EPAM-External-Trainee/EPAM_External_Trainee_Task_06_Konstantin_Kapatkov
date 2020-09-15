using BLL.Reports.Excel.Views.SessionResultReport.TableRowViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews
{
    /// <summary>Interface describing the view of the group table</summary>
    public interface IGroupTableView
    {
        /// <summary>Table headers</summary>
        string[] Headers { get; }

        /// <summary><see cref="GroupTableRowView"/> as table raw views</summary>
        IEnumerable<GroupTableRowView> TableRawViews { get; set; }

        /// <summary>Group name</summary>
        string GroupName { get; set; }

        /// <summary>Session name</summary>
        string SessionName { get; set; }
    }
}