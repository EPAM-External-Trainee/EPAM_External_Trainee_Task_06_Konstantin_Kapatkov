using DAL.ORM.Models;

namespace DAL.DAO.Models
{
    /// <summary>Class describes Dao <see cref="KnowledgeAssessmentForm"/> functionality</summary>
    public class DaoKnowledgeAssessmentForm : Dao<KnowledgeAssessmentForm>
    {
        /// <summary>Creating an instance of <see cref="DaoKnowledgeAssessmentForm"/> via connection string</summary>
        /// <param name="connectionString"></param>
        public DaoKnowledgeAssessmentForm(string connectionString) : base(connectionString)
        {
        }
    }
}