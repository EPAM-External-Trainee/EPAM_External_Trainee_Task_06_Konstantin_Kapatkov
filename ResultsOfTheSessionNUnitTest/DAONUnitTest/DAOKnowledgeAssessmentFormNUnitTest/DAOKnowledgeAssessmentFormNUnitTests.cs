using NUnit.Framework;
using ResultsOfTheSession.ORM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSessionNUnitTest.DAONUnitTest.DAOKnowledgeAssessmentFormNUnitTest
{
    [TestFixture]
    public class DAOKnowledgeAssessmentFormNUnitTests : DAOTest
    {
        [TestCase("Unknown")]
        public void CreateKnowledgeAssessmentForm_Test(string knowledgeAssessmentFormName)
        {
            KnowledgeAssessmentForm knowledgeAssessmentForm = new KnowledgeAssessmentForm(knowledgeAssessmentFormName);
            bool result = Task.Run(async () => await DaoFactoryTest.GetKnowledgeAssessmentForm().CreateAsync(knowledgeAssessmentForm).ConfigureAwait(false)).Result;
            Assert.AreEqual(knowledgeAssessmentForm.Form, Task.Run(async () => await DaoFactoryTest.GetKnowledgeAssessmentForm().ReadAllAsync().ConfigureAwait(false)).Result.Last().Form);
            Assert.IsTrue(result);
        }

        [TestCase(1, "Exam")]
        public void ReadKnowledgeAssessmentForm_Test(int id, string form)
        {
            KnowledgeAssessmentForm knowledgeAssessmentForm = Task.Run(async () => await DaoFactoryTest.GetKnowledgeAssessmentForm().ReadAsync(id).ConfigureAwait(false)).Result;
            Assert.AreEqual(knowledgeAssessmentForm, new KnowledgeAssessmentForm(id, form));
        }

        [TestCase(2, "Unknown")]
        public void UpdateKnowledgeAssessmentForm_Test(int id, string form)
        {
            KnowledgeAssessmentForm knowledgeAssessmentForm = new KnowledgeAssessmentForm(id, form);
            bool result = Task.Run(async () => await DaoFactoryTest.GetKnowledgeAssessmentForm().UpdateAsync(knowledgeAssessmentForm).ConfigureAwait(false)).Result;
            Assert.AreEqual(knowledgeAssessmentForm, Task.Run(async () => await DaoFactoryTest.GetKnowledgeAssessmentForm().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [TestCase(1)]
        public void DeleteKnowledgeAssessmentForm_Test(int id)
        {
            bool result = Task.Run(async () => await DaoFactoryTest.GetKnowledgeAssessmentForm().DeleteAsync(id).ConfigureAwait(false)).Result;
            Assert.IsNull(Task.Run(async () => await DaoFactoryTest.GetKnowledgeAssessmentForm().ReadAsync(id).ConfigureAwait(false)).Result);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadAllKnowledgeAssessmentForm_Test()
        {
            IEnumerable<KnowledgeAssessmentForm> result = Task.Run(async () => await DaoFactoryTest.GetKnowledgeAssessmentForm().ReadAllAsync().ConfigureAwait(false)).Result;
            Assert.IsTrue(result != null && result.Count() != 0);
        }
    }
}