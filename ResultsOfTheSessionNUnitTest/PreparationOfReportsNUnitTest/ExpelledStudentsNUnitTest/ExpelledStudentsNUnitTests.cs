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

        [TestCase(1, false)]
        public void ReportExpelledStudents_OrderByName_Test(int sessionId, bool descOrder)
        {
            ExpelledStudentsReport expelledStudents = new ExpelledStudentsReport(ConnectionString);
            MyExcelWorker.WriteToExcel(expelledStudents.GetReportData(sessionId, r => r.Name, descOrder), PathToExpelledStudentsExcelFile);
        }

        [TestCase(1, true)]
        public void ReportExpelledStudents_OrderBySurname_Test(int sessionId, bool descOrder)
        {
            ExpelledStudentsReport expelledStudents = new ExpelledStudentsReport(ConnectionString);
            MyExcelWorker.WriteToExcel(expelledStudents.GetReportData(sessionId, r => r.Surname, descOrder), PathToExpelledStudentsExcelFile);
        }

        [TestCase(1, false)]
        public void ReportExpelledStudents_OrderByPatronymic_Test(int sessionId, bool descOrder)
        {
            ExpelledStudentsReport expelledStudents = new ExpelledStudentsReport(ConnectionString);
            MyExcelWorker.WriteToExcel(expelledStudents.GetReportData(sessionId, r => r.Patronymic, descOrder), PathToExpelledStudentsExcelFile);
        }
    }
}