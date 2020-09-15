using DAL.DAO.Interfaces;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Models
{
    /// <summary>Class describes factory to create Dao instances</summary>
    /// <remarks>Applied singleton pattern</remarks>
    public sealed class DaoFactory : IDaoFactory
    {
        /// <summary>Class instance</summary>
        private static DaoFactory _instance;

        /// <summary>SQL Server connection string</summary>
        private static string _connectionString;

        /// <summary>Default constructor</summary>
        /// <remarks>Private</remarks>
        private DaoFactory()
        {
        }

        /// <summary>Getting instance of class</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        /// <returns>Instance of <see cref="DaoFactory"/></returns>
        public static DaoFactory GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DaoFactory();
                _connectionString = connectionString;
            }
            return _instance;
        }

        /// <inheritdoc cref="IDaoFactory.GetGender"/>
        public IDao<Gender> GetGender() => new DaoGender(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetGroup"/>
        public IDao<Group> GetGroup() => new DaoGroup(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetKnowledgeAssessmentForm"/>
        public IDao<KnowledgeAssessmentForm> GetKnowledgeAssessmentForm() => new DaoKnowledgeAssessmentForm(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetSession"/>
        public IDao<Session> GetSession() => new DaoSession(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetSessionResult"/>
        public IDao<SessionResult> GetSessionResult() => new DaoSessionResult(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetSessionSchedule"/>
        public IDao<SessionSchedule> GetSessionSchedule() => new DaoSessionSchedule(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetStudent"/>
        public IDao<Student> GetStudent() => new DaoStudent(_connectionString);

        /// <inheritdoc cref="IDaoFactory.GetSubject"/>
        public IDao<Subject> GetSubject() => new DaoSubject(_connectionString);
    }
}