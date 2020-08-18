using ResultsOfTheSession.Interfaces.SessionPart.KnowledgeAssessmentFormPart;
using System.Collections.Generic;

namespace ResultsOfTheSession.Interfaces
{
    interface IResultSession
    {
        int Id { get; set; }

        IEnumerable<ICreditResult> CreditResults { get; set; }

        IEnumerable<IExamResult> ExamResults { get; set; }

        int StudentId { get; set; }
    }
}