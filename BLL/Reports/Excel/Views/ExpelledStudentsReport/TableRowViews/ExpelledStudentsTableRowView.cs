using BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableRowViews;

namespace BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews
{
    public struct ExpelledStudentsTableRowView : IExpelledStudentsTableRowView
    {
        public ExpelledStudentsTableRowView(string name, string surname, string patronumic)
        {
            StudentName = name;
            StudentSurname = surname;
            StudentPatronymic = patronumic;
        }

        public string StudentName { get; set; }

        public string StudentSurname { get; set; }

        public string StudentPatronymic { get; set; }
    }
}