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
            SessionResultWithGroupMarks reportWithGroupMarks = new SessionResultWithGroupMarks(ConnectionString);
            MyExcelWorker.WriteToExcel(reportWithGroupMarks.GetReportData(p => p.MaxAssessment, true), PathToSessionResultWithGroupMarksExcelFile);
        }
    }
}