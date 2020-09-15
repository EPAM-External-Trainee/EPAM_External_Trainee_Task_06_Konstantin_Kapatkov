using ResultsOfTheSession.DAO.Interfaces;
using ResultsOfTheSession.DAO.Models;
using ResultsOfTheSession.ORM.Models;
using ResultsOfTheSession.ORM.Models.Session;

namespace ResultsOfTheSession.DAO
{
    public sealed class DaoFactory : IDaoFactory
    {
        private static DaoFactory _instance;
        private static string _connectionString;

        private DaoFactory()
        {
        }

        public static DaoFactory GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DaoFactory();
                _connectionString = connectionString;
            }
            return _instance;
        }

        public IDao<Gender> GetGender() => new DaoGender(_connectionString);

        public IDao<Group> GetGroup() => new DaoGroup(_connectionString);

        public IDao<KnowledgeAssessmentForm> GetKnowledgeAssessmentForm() => new DaoKnowledgeAssessmentForm(_connectionString);

        public IDao<Session> GetSession() => new DaoSession(_connectionString);

        public IDao<SessionResult> GetSessionResult() => new DaoSessionResult(_connectionString);

        public IDao<SessionSchedule> GetSessionSchedule() => new DaoSessionSchedule(_connectionString);

        public IDao<Student> GetStudent() => new DaoStudent(_connectionString);

        public IDao<Subject> GetSubject() => new DaoSubject(_connectionString);
    }
}