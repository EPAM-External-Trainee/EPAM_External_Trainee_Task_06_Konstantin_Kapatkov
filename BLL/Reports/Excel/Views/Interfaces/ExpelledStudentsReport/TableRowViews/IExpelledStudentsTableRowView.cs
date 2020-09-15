namespace BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableRowViews
{
    public interface IExpelledStudentsTableRowView
    {
        string StudentName { get; set; }

        string StudentSurname { get; set; }

        string StudentPatronymic { get; set; }
    }
}