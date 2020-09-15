namespace BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableRowViews
{
    /// <summary>Interface describing the row view of the expelled students table</summary>
    public interface IExpelledStudentsTableRowView
    {
        /// <summary>Student name</summary>
        string StudentName { get; set; }

        /// <summary>Student surname</summary>
        string StudentSurname { get; set; }

        /// <summary>Student patronymic</summary>
        string StudentPatronymic { get; set; }
    }
}