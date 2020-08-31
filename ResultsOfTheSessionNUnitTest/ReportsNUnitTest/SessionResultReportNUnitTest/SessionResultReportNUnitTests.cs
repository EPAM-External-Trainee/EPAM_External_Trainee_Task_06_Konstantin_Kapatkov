using NUnit.Framework;
using ResultsOfTheSession.ExcelWorker;
using ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport;

namespace ResultsOfTheSessionNUnitTest.PreparationOfReportsNUnitTest.SessionResultForGroupNUnitTest
{
    [TestFixture]
    public class SessionResultReportNUnitTests : PreparationOfReports
    {
        [TestCase(1)]
        public void ReportSessionResultForGroup_Test(int sessionId)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId), PathToSessionResultForGroupExcelFile);
        }

        [TestCase(2, false)]
        public void ReportSessionResultForGroup_OrderByName_Test(int sessionId, bool descOrder)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId, r => r.Name, descOrder), PathToSessionResultForGroupExcelFile);
        }

        [TestCase(1, false)]
        public void ReportSessionResultForGroup_OrderBySurname_Test(int sessionId, bool descOrder)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId, r => r.Surname, descOrder), PathToSessionResultForGroupExcelFile);
        }

        [TestCase(2, true)]
        public void ReportSessionResultForGroup_OrderByPatronymic_Test(int sessionId, bool descOrder)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId, r => r.Patronymic, descOrder), PathToSessionResultForGroupExcelFile);
        }

        [TestCase(1, false)]
        public void ReportSessionResultForGroup_OrderBySubject_Test(int sessionId, bool descOrder)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId, r => r.Subject, descOrder), PathToSessionResultForGroupExcelFile);
        }

        [TestCase(1, true)]
        public void ReportSessionResultForGroup_OrderByForm_Test(int sessionId, bool descOrder)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId, r => r.Form, descOrder), PathToSessionResultForGroupExcelFile);
        }

        [TestCase(2, true)]
        public void ReportSessionResultForGroup_OrderByDate_Test(int sessionId, bool descOrder)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId, r => r.Date, descOrder), PathToSessionResultForGroupExcelFile);
        }

        [TestCase(2, false)]
        public void ReportSessionResultForGroup_OrderByAssessment_Test(int sessionId, bool descOrder)
        {
            SessionResultReport sessionResultForGroup = new SessionResultReport(ConnectionString);
            MyExcelWorker.WriteToExcel(sessionResultForGroup.GetReportData(sessionId, r => r.Assessment, descOrder), PathToSessionResultForGroupExcelFile);
        }
    }
}