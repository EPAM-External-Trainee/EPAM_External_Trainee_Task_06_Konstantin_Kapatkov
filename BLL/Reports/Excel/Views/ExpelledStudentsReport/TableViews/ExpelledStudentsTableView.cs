using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableViews;
using System.Collections.Generic;

namespace BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews
{
    public class ExpelledStudentsTableView : IExpelledStudentsTableView
    {
        public ExpelledStudentsTableView(IEnumerable<ExpelledStudentsTableRowView> tableRowViews, string groupName)
        {
            TableRowViews = tableRowViews;
            GroupName = groupName;
        }

        public string[] Headers { get; } = { "Surname", "Name", "Patronymic" };

        public IEnumerable<ExpelledStudentsTableRowView> TableRowViews { get; set; }

        public string GroupName { get; set; }
    }
}