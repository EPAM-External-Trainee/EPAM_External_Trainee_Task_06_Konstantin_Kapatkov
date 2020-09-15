using BLL.Reports.Excel;
using BLL.Reports.Interfaces.ExpelledStudentsReport;
using BLL.Reports.Models.ExpelledStudentsReport;
using NUnit.Framework;
using System.IO;

namespace ResultsOfTheSessionNUnitTestProject.ReportsNUnitTest.ExpelledStudentsReportNUnitTest
{
    /// <summary>Class describes functionality for testing <see cref="ExpelledStudentsReport"/> class</summary>
    [TestFixture]
    public class ExpelledStudentsReportNUnitTest : ReportsUnitTestData
    {
        private IExpelledStudentsReport Report { get; } = new ExpelledStudentsReport(ConnectionString);

        [Test]
        [TestCase(1)]
        public void GroupExpelledStudentsReport_Test(int sessionId)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId), PathToExpelledStudentsReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void GroupExpelledStudentsReport_OrderBy_StudentName_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentName, isDesc), PathToExpelledStudentsReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void GroupExpelledStudentsReport_OrderByDescending_StudentName_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentName, isDesc), PathToExpelledStudentsReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void GroupExpelledStudentsReport_OrderBy_StudentSurname_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentSurname, isDesc), PathToExpelledStudentsReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void GroupExpelledStudentsReport_OrderByDescending_StudentSurname_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentSurname, isDesc), PathToExpelledStudentsReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void GroupExpelledStudentsReport_OrderBy_StudentPatronymic_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentPatronymic, isDesc), PathToExpelledStudentsReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void GroupExpelledStudentsReport_OrderByDescending_StudentPatronymic_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentPatronymic, isDesc), PathToExpelledStudentsReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }
    }
}