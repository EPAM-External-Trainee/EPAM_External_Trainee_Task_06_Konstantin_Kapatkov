using BLL.Reports.Excel;
using BLL.Reports.Models.SessionResultReportData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTestProject.ReportsNUnitTest.SessionResultReportNUnitTest
{
    /// <summary>Class describes functionality for testing <see cref="SessionResultReport"/> class</summary>
    [TestFixture]
    public class SessionResultReportUnitTests : ReportsUnitTestData
    {
        public static SessionResultReport Report = new SessionResultReport(ConnectionString);

        [Test]
        [TestCase(1)]
        public void SessionResultReport_Test(int sessionId)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Assessment_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Assessment, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Assessment_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Assessment, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Date_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Date, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Date_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Date, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Form_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.AssessmentForm, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Form_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.AssessmentForm, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Name_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentName, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Name_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentName, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Surname_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentSurname, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Surname_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentSurname, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Patronymic_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentPatronymic, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Patronymic_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.StudentPatronymic, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, false)]
        public void SessionResultReport_GroupTable_OrderBy_Subject_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Subject, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(1, true)]
        public void SessionResultReport_GroupTable_OrderByDesceding_Subject_Test(int sessionId, bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId, r => r.Subject, isDesc), PathToSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToSessionResultReportExcelFile));
        }
    }
}