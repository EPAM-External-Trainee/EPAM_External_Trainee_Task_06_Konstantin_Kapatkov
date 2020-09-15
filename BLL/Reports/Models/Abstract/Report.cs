using BLL.Reports.Interfaces;
using DAL.DAO.Models;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;

namespace BLL.Reports.Models.Abstract
{
    /// <summary>Class describes data for report operations</summary>
    public abstract class Report : IReport
    {
        /// <summary>Constructor for initializing data</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        protected Report(string connectionString)
        {
            DaoFactory = DaoFactory.GetInstance(connectionString);

            Sessions = DaoFactory.GetSession().TryReadAllAsync().Result;
            SessionResults = DaoFactory.GetSessionResult().TryReadAllAsync().Result;
            SessionSchedules = DaoFactory.GetSessionSchedule().TryReadAllAsync().Result;
            Groups = DaoFactory.GetGroup().TryReadAllAsync().Result;
            KnowledgeAssessmentForms = DaoFactory.GetKnowledgeAssessmentForm().TryReadAllAsync().Result;
            Students = DaoFactory.GetStudent().TryReadAllAsync().Result;
            Subjects = DaoFactory.GetSubject().TryReadAllAsync().Result;
        }

        /// <inheritdoc cref="IReport.DaoFactory"/>
        public DaoFactory DaoFactory { get; set; }

        /// <inheritdoc cref="IReport.Sessions"/>
        public IEnumerable<Session> Sessions { get; set; }

        /// <inheritdoc cref="IReport.SessionResults"/>
        public IEnumerable<SessionResult> SessionResults { get; set; }

        /// <inheritdoc cref="IReport.SessionSchedules"/>
        public IEnumerable<SessionSchedule> SessionSchedules { get; set; }

        /// <inheritdoc cref="IReport.Groups"/>
        public IEnumerable<Group> Groups { get; set; }

        /// <inheritdoc cref="IReport.KnowledgeAssessmentForms"/>
        public IEnumerable<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        /// <inheritdoc cref="IReport.Students"/>
        public IEnumerable<Student> Students { get; set; }

        /// <inheritdoc cref="IReport.Subjects"/>
        public IEnumerable<Subject> Subjects { get; set; }
    }
}