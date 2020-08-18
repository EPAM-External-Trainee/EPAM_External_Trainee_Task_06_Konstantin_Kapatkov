namespace ResultsOfTheSession.Interfaces
{
    public interface IExamResult : IKnowledgeAssessmentFormInfo
    {
        double Result { get; set; }
    }
}