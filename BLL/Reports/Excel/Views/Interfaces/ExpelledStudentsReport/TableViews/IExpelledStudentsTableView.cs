using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableViews
{
    public interface IExpelledStudentsTableView
    {
        string[] Headers { get; }

        IEnumerable<ExpelledStudentsTableRowView> TableRowViews { get; set; }

        string GroupName { get; set; }
    }
}