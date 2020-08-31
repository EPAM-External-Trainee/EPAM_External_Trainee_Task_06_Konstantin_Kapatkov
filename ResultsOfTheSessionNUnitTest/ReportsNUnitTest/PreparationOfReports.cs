namespace ResultsOfTheSessionNUnitTest.PreparationOfReportsNUnitTest
{
    public abstract class PreparationOfReports
    {
        protected const string ConnectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;";

        protected const string PathToExpelledStudentsExcelFile = @"..\..\..\..\ResultsOfTheSessionNUnitTest\ReportsNUnitTest\Resources\ExpelledStudentsReport.xlsx";

        protected const string PathToSessionResultForGroupExcelFile = @"..\..\..\..\ResultsOfTheSessionNUnitTest\ReportsNUnitTest\Resources\SessionResultReport.xlsx";

        protected const string PathToSessionResultWithGroupMarksExcelFile = @"..\..\..\..\ResultsOfTheSessionNUnitTest\ReportsNUnitTest\Resources\GroupSessionResult.xlsx";
    }
}