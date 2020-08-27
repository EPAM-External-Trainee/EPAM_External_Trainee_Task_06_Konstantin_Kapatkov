using ResultsOfTheSession.PreparationOfReports.Interfaces.ExpelledStudentsReport;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport
{
    public struct ExpelledStudentsReportData : IExpelledStudentsReportData
    {
        public ExpelledStudentsReportData(IEnumerable<ExpelledStudentsReportRawView> expelledStudentsReportRawViews, string academicYear, string groupName)
        {
            ExpelledStudentsReportRawViews = expelledStudentsReportRawViews;
            AcademicYear = academicYear;
            GroupName = groupName;
            Headers = new string[] { "Surname", "Name", "Patronymic" };
        }

        public IEnumerable<ExpelledStudentsReportRawView> ExpelledStudentsReportRawViews { get; set; }

        public string AcademicYear { get; set; }

        public string GroupName { get; set; }

        public string[] Headers { get; set; }

        public override bool Equals(object obj) => obj is ExpelledStudentsReportData data && ExpelledStudentsReportRawViews.SequenceEqual(data.ExpelledStudentsReportRawViews) && AcademicYear == data.AcademicYear && GroupName == data.GroupName && Headers.SequenceEqual(data.Headers);

        public override int GetHashCode() => HashCode.Combine(ExpelledStudentsReportRawViews, AcademicYear, GroupName, Headers);
    }
}