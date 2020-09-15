using BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableRowViews;

namespace BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews
{
    public struct ExpelledStudentsTableRowView : IExpelledStudentsTableRowView
    {
        public ExpelledStudentsTableRowView(string name, string surname, string patronumic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronumic;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

    }
}