using System;

namespace ResultsOfTheSession.Interfaces
{
    public interface IKnowledgeAssessmentFormInfo
    {
        int Id { get; set; }

        ISubject Subject { get; set; }

        DateTime TimeOfTheKnowledgeAssessment { get; set; }
    }
}