using ResultsOfTheSession.PreparationOfReports.Interfaces.ExpelledStudentsReport;
using System;

namespace ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport
{
    public struct ExpelledStudentsReportRawView : IExpelledStudentsReportRowView
    {
        public ExpelledStudentsReportRawView(string name, string surname, string patronymic) => (Name, Surname, Patronymic) = (name, surname, patronymic);

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public override bool Equals(object obj) => obj is ExpelledStudentsReportRawView view && Name == view.Name && Surname == view.Surname && Patronymic == view.Patronymic;

        public override int GetHashCode() => HashCode.Combine(Name, Surname, Patronymic);
    }
}