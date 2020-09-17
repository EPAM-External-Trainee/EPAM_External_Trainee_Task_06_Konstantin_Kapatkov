using BLL.Reports.Excel;
using BLL.Reports.Interfaces.GroupSessionResultReport;
using BLL.Reports.Models.GroupSessionResultReportData;
using NUnit.Framework;
using System.IO;

namespace ResultsOfTheSessionNUnitTestProject.ReportsNUnitTest.GroupSessionResultReportNUnitTest
{
    /// <summary>Class describes functionality for testing <see cref="GroupSessionResultReport"/> class</summary>
    [TestFixture]
    public class GroupSessionResultReportUnitTests : ReportsUnitTestData
    {
        private static IGroupSessionResultReport Report { get; } = new GroupSessionResultReport();

        [Test]
        public void GroupSessionResultReport_Test()
        {
            ExcelWriter.WriteToExcel(Report.GetReport(), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(false)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderBy_GroupName_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.GroupName, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(true)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderByDescending_GroupName_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.GroupName, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(false)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderBy_MaxAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.MaxAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(true)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderByDescending_MaxAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.MaxAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(false)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderBy_MinAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.MinAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(true)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderByDescending_MinAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.MinAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(false)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderBy_AvgAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.AvgAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }

        [Test]
        [TestCase(true)]
        public void GroupSessionResultReport_GropuSessionResultTable_OrderByDescending_AvgAssessment_Test(bool isDesc)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(r => r.AvgAssessment, isDesc), PathToGroupSessionResultReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }
    }
}