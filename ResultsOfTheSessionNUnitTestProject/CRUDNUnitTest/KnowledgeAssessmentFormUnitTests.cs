using DAL.ORM.Models;
using NUnit.Framework;

namespace ResultsOfTheSessionNUnitTestProject.CRUDNUnitTest
{
    /// <summary>Class describes testing CRUD functionality for <see cref="KnowledgeAssessmentForm"/> model</summary>
    [TestFixture]
    public class KnowledgeAssessmentFormUnitTests : CRUDUnitTestData
    {
        [Test]
        [TestCase("Unknown")]
        public void CreateKnowledgeAssessmentForm_IsTrue_Test(string name)
        {
            Assert.IsTrue(DaoFactory.GetKnowledgeAssessmentForm().TryCreateAsync(new KnowledgeAssessmentForm(name)).Result);
        }

        [Test]
        [TestCase(1)]
        public void ReadKnowledgeAssessmentForm_IsNotNull_Test(int id)
        {
            Assert.IsNotNull(DaoFactory.GetKnowledgeAssessmentForm().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(10)]
        public void ReadKnowledgeAssessmentForm_IsNull_Test(int id)
        {
            Assert.IsNull(DaoFactory.GetKnowledgeAssessmentForm().TryReadAsync(id).Result);
        }

        [Test]
        [TestCase(1, "Unknown")]
        public void UpdateKnowledgeAssessmentForm_IsTrue_Test(int id, string name)
        {
            Assert.IsTrue(DaoFactory.GetKnowledgeAssessmentForm().TryUpdateAsync(new KnowledgeAssessmentForm(id, name)).Result);
        }

        [Test]
        [TestCase(10, "Unknown")]
        public void UpdateKnowledgeAssessmentForm_IsFalse_Test(int id, string name)
        {
            Assert.IsFalse(DaoFactory.GetKnowledgeAssessmentForm().TryUpdateAsync(new KnowledgeAssessmentForm(id, name)).Result);
        }

        [Test]
        [TestCase(1)]
        public void DeleteKnowledgeAssessmentForm_IsTrue_Test(int id)
        {
            Assert.IsTrue(DaoFactory.GetKnowledgeAssessmentForm().TryDeleteAsync(id).Result);
        }

        [Test]
        [TestCase(10)]
        public void DeleteKnowledgeAssessmentForm_IsFalse_Test(int id)
        {
            Assert.IsFalse(DaoFactory.GetKnowledgeAssessmentForm().TryDeleteAsync(id).Result);
        }

        [Test]
        public void ReadAllKnowledgeAssessmentForms_IsNotNull_Test()
        {
            Assert.IsNotNull(DaoFactory.GetKnowledgeAssessmentForm().TryReadAllAsync().Result);
        }
    }
}