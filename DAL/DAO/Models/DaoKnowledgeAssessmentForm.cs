using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    public class DaoKnowledgeAssessmentForm : Dao<KnowledgeAssessmentForm>
    {
        public DaoKnowledgeAssessmentForm(string connectionString) : base(connectionString)
        {
        }
    }
}