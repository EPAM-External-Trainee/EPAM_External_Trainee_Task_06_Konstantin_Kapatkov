using ResultsOfTheSession.DAO;
using ResultsOfTheSession.ORM.Models;
using ResultsOfTheSession.ORM.Models.Session;
using ResultsOfTheSession.PreparationOfReports.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Abstract
{
    public abstract class Report : IReport
    {
        protected Report(string connectionString)
        {
            DaoFactory = DaoFactory.GetInstance(connectionString);

            Sessions = DaoFactory.GetSession().ReadAll().ToList();
            SessionResults = DaoFactory.GetSessionResult().ReadAll().ToList();
            SessionSchedules = DaoFactory.GetSessionSchedule().ReadAll().ToList();
            Groups = DaoFactory.GetGroup().ReadAll().ToList();
            KnowledgeAssessmentForms = DaoFactory.GetKnowledgeAssessmentForm().ReadAll().ToList();
            Students = DaoFactory.GetStudent().ReadAll().ToList();
            Subjects = DaoFactory.GetSubject().ReadAll().ToList();
        }

        public DaoFactory DaoFactory { get; set; }

        public List<Session> Sessions { get; set; }

        public List<SessionResult> SessionResults { get; set; }

        public List<SessionSchedule> SessionSchedules { get; set; }

        public List<Group> Groups { get; set; }

        public List<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        public List<Student> Students { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}