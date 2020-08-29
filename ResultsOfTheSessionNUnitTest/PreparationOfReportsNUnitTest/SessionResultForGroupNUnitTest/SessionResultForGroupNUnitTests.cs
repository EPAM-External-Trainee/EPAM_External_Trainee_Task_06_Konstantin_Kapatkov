using NUnit.Framework;
using ResultsOfTheSession.ExcelWorker;
using ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport;

namespace ResultsOfTheSessionNUnitTest.PreparationOfReportsNUnitTest.SessionResultForGroupNUnitTest
{
    [TestFixture]
    public class SessionResultForGroupNUnitTests : PreparationOfReports
    {
        [TestCase(2)]
        public void ReportSessionResultForGroup_Test(int sessionId)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId, s => s.Assessment, false), PathToSessionResultForGroupExcelFile);
        }
    }
}