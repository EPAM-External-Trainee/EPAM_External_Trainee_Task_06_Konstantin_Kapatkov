using ResultsOfTheSession.ORM.Interfaces;

namespace ResultsOfTheSession.ORM.Models
{
    public class KnowledgeAssessmentForm : IKnowledgeAssessmentForm
    {
        public int Id { get; set; }

        public string Form { get; set; }
    }
}