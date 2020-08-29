using NUnit.Framework;
using ResultsOfTheSession.ExcelWorker;
using ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport;

namespace ResultsOfTheSessionNUnitTest.PreparationOfReportsNUnitTest
{
    [TestFixture]
    public class ExpelledStudentsNUnitTests : PreparationOfReports
    {
        [TestCase(1)]
        public void ReportExpelledStudents_Test(int sessionId)
        {
            ExpelledStudentsReport expelledStudents = new ExpelledStudentsReport(ConnectionString);
            MyExcelWorker.WriteToExcel(expelledStudents.GetReportData(sessionId), PathToExpelledStudentsExcelFile);
        }
    }
}