using DAL.ORM.Interfaces;
using System;

namespace DAL.ORM.Models
{
    /// <summary>Class describes knowledge assessment form model</summary>
    public class KnowledgeAssessmentForm : IKnowledgeAssessmentForm
    {
        /// <summary>Default constructor</summary>
        public KnowledgeAssessmentForm()
        {
        }

        /// <summary>Creating an instance of <see cref="KnowledgeAssessmentForm"/> via from name</summary>
        /// <param name="form">Knowledge assessment form name</param>
        public KnowledgeAssessmentForm(string form) => Form = form;

        /// <summary>Creating an instance of <see cref="KnowledgeAssessmentForm"/> via id and from name</summary>
        /// <param name="id">Knowledge assessment form id</param>
        /// <param name="form">Knowledge assessment form name</param>
        public KnowledgeAssessmentForm(int id, string form) => (Id, Form) = (id, form);

        /// <inheritdoc cref=" IKnowledgeAssessmentForm.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref=" IKnowledgeAssessmentForm.Form"/>
        public string Form { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is KnowledgeAssessmentForm form && Id == form.Id && Form == form.Form;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Id, Form);
    }
}