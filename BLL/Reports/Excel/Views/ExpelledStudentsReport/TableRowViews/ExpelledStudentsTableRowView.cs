using BLL.Reports.Excel.Views.Interfaces.ExpelledStudentsReport.TableRowViews;
using System;

namespace BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews
{
    /// <summary>Class describing the row view of the expelled students table</summary>
    public struct ExpelledStudentsTableRowView : IExpelledStudentsTableRowView
    {
        /// <summary>Creating an instance of <see cref="ExpelledStudentsTableRowView"/> via student name, surname and patronumic</summary>
        /// <param name="name">Student name</param>
        /// <param name="surname">Student surname</param>
        /// <param name="patronymic">Student patronymic</param>
        public ExpelledStudentsTableRowView(string name, string surname, string patronymic)
        {
            StudentName = name;
            StudentSurname = surname;
            StudentPatronymic = patronymic;
        }

        /// <inheritdoc cref="IExpelledStudentsTableRowView.StudentName"/>
        public string StudentName { get; set; }

        /// <inheritdoc cref="IExpelledStudentsTableRowView.StudentSurname"/>
        public string StudentSurname { get; set; }

        /// <inheritdoc cref="IExpelledStudentsTableRowView.StudentPatronymic"/>
        public string StudentPatronymic { get; set; }

        public override bool Equals(object obj) => obj is ExpelledStudentsTableRowView view && StudentName == view.StudentName && StudentSurname == view.StudentSurname && StudentPatronymic == view.StudentPatronymic;

        public override int GetHashCode() => HashCode.Combine(StudentName, StudentSurname, StudentPatronymic);
    }
}