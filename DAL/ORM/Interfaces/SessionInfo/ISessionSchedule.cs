using System;

namespace DAL.ORM.Interfaces.SessionInfo
{
    /// <summary>Interface describes session schedule model</summary>
    public interface ISessionSchedule
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Session id</summary>
        int SessionId { get; set; }

        /// <summary>Group id</summary>
        int GroupId { get; set; }

        /// <summary>Subject id</summary>
        int SubjectId { get; set; }

        /// <summary>Date of exam or credit</summary>
        DateTime Date { get; set; }

        /// <summary>Knowledge assessment form id</summary>
        int KnowledgeAssessmentFormId { get; set; }
    }
}