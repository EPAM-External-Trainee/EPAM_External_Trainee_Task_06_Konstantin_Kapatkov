namespace BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableRowViews
{
    public interface IExpelledStudentsTableRowView
    {
        string Name { get; set; }

        string Surname { get; set; }

        string Patronymic { get; set; }
    }
}