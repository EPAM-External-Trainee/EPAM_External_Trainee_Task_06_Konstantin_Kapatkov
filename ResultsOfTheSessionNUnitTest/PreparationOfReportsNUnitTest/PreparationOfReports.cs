namespace ResultsOfTheSessionNUnitTest.PreparationOfReportsNUnitTest
{
    public abstract class PreparationOfReports
    {
        protected string ConnectionString => @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=ResultSession; Integrated Security=true;";

        protected const string PathToExpelledStudentsExcelFile = @"..\..\..\..\ResultsOfTheSessionNUnitTest\PreparationOfReportsNUnitTest\Resources\ExpelledStudents.xlsx";

        protected const string PathToSessionResultForGroupExcelFile = @"..\..\..\..\ResultsOfTheSessionNUnitTest\PreparationOfReportsNUnitTest\Resources\SessionResultForGroup.xlsx";

        protected const string PathToSessionResultWithGroupMarksExcelFile = @"..\..\..\..\ResultsOfTheSessionNUnitTest\PreparationOfReportsNUnitTest\Resources\SessionResultWithGroupMarks.xlsx";
    }
}