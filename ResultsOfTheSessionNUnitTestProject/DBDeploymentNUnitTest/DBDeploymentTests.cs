using DAL.DB.DBDeployment;
using NUnit.Framework;

namespace ResultsOfTheSessionNUnitTestProject.DBDeploymentUnitTest
{
    /// <summary>Class describes functionality for testing <see cref="DatabaseDeployment"/> class</summary>
    [TestFixture]
    public class DBDeploymentTests
    {
        [Test]
        public void DBDeploy_IsTrue_Test()
        {
            Assert.IsTrue(DatabaseDeployment.TryExpandTheDatabaseAsync().Result);
        }
    }
}