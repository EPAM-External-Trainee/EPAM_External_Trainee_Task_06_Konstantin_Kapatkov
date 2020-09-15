namespace DAL.ORM.Interfaces
{
    /// <summary>Interface describes knowledge assessment form model</summary>
    public interface IKnowledgeAssessmentForm
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Form</summary>
        string Form { get; set; }
    }
}