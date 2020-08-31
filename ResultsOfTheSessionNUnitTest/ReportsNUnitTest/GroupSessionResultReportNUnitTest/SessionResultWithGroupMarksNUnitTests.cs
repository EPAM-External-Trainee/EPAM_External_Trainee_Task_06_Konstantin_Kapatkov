using NUnit.Framework;
using ResultsOfTheSession.ExcelWorker;
using ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport;

namespace ResultsOfTheSessionNUnitTest.PreparationOfReportsNUnitTest.SessionResultWithGroupMarksNUnitTest
{
    [TestFixture]
    public class SessionResultWithGroupMarksNUnitTests : PreparationOfReports
    {
        [Test]
        public void ReportWithGroupMarks_Test()
        {
            GroupSessionResultReport reportWithGroupMarks = new GroupSessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(reportWithGroupMarks.GetReportData(), PathToSessionResultWithGroupMarksExcelFile);
        }

        [TestCase(true)]
        public void ReportWithGroupMarks_OrderByGroupName_Test(bool descOrder)
        {
            GroupSessionResultReport reportWithGroupMarks = new GroupSessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(reportWithGroupMarks.GetReportData(p => p.GroupName, descOrder), PathToSessionResultWithGroupMarksExcelFile);
        }

        [TestCase(false)]
        public void ReportWithGroupMarks_OrderByMaxAssessment_Test(bool descOrder)
        {
            GroupSessionResultReport reportWithGroupMarks = new GroupSessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(reportWithGroupMarks.GetReportData(p => p.MaxAssessment, descOrder), PathToSessionResultWithGroupMarksExcelFile);
        }

        [TestCase(true)]
        public void ReportWithGroupMarks_OrderByMinAssessment_Test(bool descOrder)
        {
            GroupSessionResultReport reportWithGroupMarks = new GroupSessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(reportWithGroupMarks.GetReportData(p => p.MinAssessment, descOrder), PathToSessionResultWithGroupMarksExcelFile);
        }

        [TestCase(false)]
        public void ReportWithGroupMarks_OrderByAvgAssessment_Test(bool descOrder)
        {
            GroupSessionResultReport reportWithGroupMarks = new GroupSessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(reportWithGroupMarks.GetReportData(p => p.AvgAssessment, descOrder), PathToSessionResultWithGroupMarksExcelFile);
        }
    }
}