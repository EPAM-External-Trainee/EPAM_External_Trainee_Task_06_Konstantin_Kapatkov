using ResultsOfTheSession.PreparationOfReports.Interfaces;
using System;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport
{
    public struct SessionResultForGroupReportRawView : ISessionResultForGroupReportRawView
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Subject { get; set; }

        public string Form { get; set; }

        public string Date { get; set; }

        public string Assessment { get; set; }

        public override bool Equals(object obj) => obj is SessionResultForGroupReportRawView view && Surname == view.Surname && Name == view.Name && Patronymic == view.Patronymic && Subject == view.Subject && Form == view.Form && Date == view.Date && Assessment == view.Assessment;

        public override int GetHashCode() => HashCode.Combine(Surname, Name, Patronymic, Subject, Form, Date, Assessment);
    }
}