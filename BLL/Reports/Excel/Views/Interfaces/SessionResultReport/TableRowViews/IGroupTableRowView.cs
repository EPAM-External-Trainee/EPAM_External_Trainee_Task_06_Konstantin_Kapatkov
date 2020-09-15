namespace BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRowViews
{
    /// <summary>Interface describing the row view of the group table</summary>
    public interface IGroupTableRowView
    {
        /// <summary>Student surname</summary>
        string StudentSurname { get; set; }

        /// <summary>Student name</summary>
        string StudentName { get; set; }

        /// <summary>Student patronymic</summary>
        string StudentPatronymic { get; set; }

        /// <summary>Subject name</summary>
        string Subject { get; set; }

        /// <summary>Assessment form name</summary>
        string AssessmentForm { get; set; }

        /// <summary>Date of exam or credit</summary>
        string Date { get; set; }

        /// <summary>Assessment</summary>
        string Assessment { get; set; }
    }
}