using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableRowViews;

namespace BLL.Reports.Excel.Views.SessionResultReport.TableRowViews
{
    /// <summary>Struct describing the row view of the group table</summary>
    public struct GroupTableRowView : IGroupTableRowView
    {
        /// <summary>Creating an instance of <see cref="GroupTableRowView"/> via student name, surname, patronymic, subject name, assessment form, date, assessment</summary>
        /// <param name="name">Student name</param>
        /// <param name="surname">Student surname</param>
        /// <param name="patronymic">Student patronymic</param>
        /// <param name="subject">Subject name</param>
        /// <param name="form">Assessment form name</param>
        /// <param name="date">Date of exam or credit</param>
        /// <param name="assessment">Assessment</param>
        public GroupTableRowView(string name, string surname, string patronymic, string subject, string form, string date, string assessment)
        {
            StudentName = name;
            StudentSurname = surname;
            StudentPatronymic = patronymic;
            Subject = subject;
            AssessmentForm = form;
            Date = date;
            Assessment = assessment;
        }

        /// <inheritdoc cref="IGroupTableRowView.StudentName"/>
        public string StudentName { get; set; }

        /// <inheritdoc cref="IGroupTableRowView.StudentSurname"/>
        public string StudentSurname { get; set; }

        /// <inheritdoc cref="IGroupTableRowView.StudentPatronymic"/>
        public string StudentPatronymic { get; set; }

        /// <inheritdoc cref="IGroupTableRowView.Subject"/>
        public string Subject { get; set; }

        /// <inheritdoc cref="IGroupTableRowView.AssessmentForm"/>
        public string AssessmentForm { get; set; }

        /// <inheritdoc cref="IGroupTableRowView.Date"/>
        public string Date { get; set; }

        /// <inheritdoc cref="IGroupTableRowView.Assessment"/>
        public string Assessment { get; set; }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj) => obj is GroupTableRowView view && StudentSurname == view.StudentSurname && StudentName == view.StudentName && StudentPatronymic == view.StudentPatronymic && Subject == view.Subject && AssessmentForm == view.AssessmentForm && Date == view.Date && Assessment == view.Assessment;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            int hashCode = 908230445;
            hashCode = hashCode * -1521134295 + StudentName.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentSurname.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentPatronymic.GetHashCode();
            hashCode = hashCode * -1521134295 + Subject.GetHashCode();
            hashCode = hashCode * -1521134295 + AssessmentForm.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Assessment.GetHashCode();
            return hashCode;
        }
    }
}