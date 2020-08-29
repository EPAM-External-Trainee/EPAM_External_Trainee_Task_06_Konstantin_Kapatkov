using ResultsOfTheSession.ORM.Interfaces;
using System;

namespace ResultsOfTheSession.ORM.Models
{
    public class KnowledgeAssessmentForm : IKnowledgeAssessmentForm
    {
        public KnowledgeAssessmentForm(string form) => Form = form;

        public KnowledgeAssessmentForm(int id, string form) => (Id, Form) = (id, form);

        public int Id { get; set; }

        public string Form { get; set; }

        public override bool Equals(object obj) => obj is KnowledgeAssessmentForm form && Id == form.Id && Form == form.Form;

        public override int GetHashCode() => HashCode.Combine(Id, Form);

        public override string ToString() => $"Knowledge assessment form id: {Id}, form: {Form}.";
    }
}