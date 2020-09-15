using BLL.Reports.Excel;
using BLL.Reports.Models.ExpelledStudentsReport;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTestProject.ReportsNUnitTest.ExpelledStudentsReportNUnitTest
{
    [TestFixture]
    public class ExpelledStudentsReportNUnitTest : ReportsUnitTestData
    {
        private ExpelledStudentsReport Report { get; } = new ExpelledStudentsReport(ConnectionString);

        [Test]
        [TestCase(1)]
        public void GroupExpelledStudentsReport_Test(int sessionId)
        {
            ExcelWriter.WriteToExcel(Report.GetReport(sessionId), PathToExpelledStudentsReportExcelFile);
            Assert.IsTrue(File.Exists(PathToGroupSessionResultReportExcelFile));
        }
    }
}