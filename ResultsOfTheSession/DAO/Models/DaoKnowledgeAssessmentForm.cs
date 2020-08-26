using ResultsOfTheSession.ORM.Models;

namespace ResultsOfTheSession.DAO.Models
{
    public class DaoKnowledgeAssessmentForm : Dao<KnowledgeAssessmentForm>
    {
        public DaoKnowledgeAssessmentForm(string connectionString) : base(connectionString)
        {
        }
    }
}