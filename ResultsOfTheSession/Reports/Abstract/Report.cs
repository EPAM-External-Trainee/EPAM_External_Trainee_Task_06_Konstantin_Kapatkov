using ResultsOfTheSession.DAO;
using ResultsOfTheSession.ORM.Models;
using ResultsOfTheSession.ORM.Models.Session;
using ResultsOfTheSession.PreparationOfReports.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultsOfTheSession.PreparationOfReports.Abstract
{
    public abstract class Report : IReport
    {
        protected Report(string connectionString)
        {
            DaoFactory = DaoFactory.GetInstance(connectionString);

            Sessions = Task.Run(async () => await DaoFactory.GetSession().ReadAllAsync().ConfigureAwait(false)).Result.ToList();
            SessionResults = Task.Run(async () => await DaoFactory.GetSessionResult().ReadAllAsync().ConfigureAwait(false)).Result.ToList();
            SessionSchedules = Task.Run(async () => await DaoFactory.GetSessionSchedule().ReadAllAsync().ConfigureAwait(false)).Result.ToList();
            Groups = Task.Run(async () => await DaoFactory.GetGroup().ReadAllAsync().ConfigureAwait(false)).Result.ToList();
            KnowledgeAssessmentForms = Task.Run(async () => await DaoFactory.GetKnowledgeAssessmentForm().ReadAllAsync().ConfigureAwait(false)).Result.ToList();
            Students = Task.Run(async () => await DaoFactory.GetStudent().ReadAllAsync().ConfigureAwait(false)).Result.ToList();
            Subjects = Task.Run(async () => await DaoFactory.GetSubject().ReadAllAsync().ConfigureAwait(false)).Result.ToList();
        }

        public DaoFactory DaoFactory { get; set; }

        public IEnumerable<Session> Sessions { get; set; }

        public IEnumerable<SessionResult> SessionResults { get; set; }

        public IEnumerable<SessionSchedule> SessionSchedules { get; set; }

        public IEnumerable<Group> Groups { get; set; }

        public IEnumerable<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }
    }
}