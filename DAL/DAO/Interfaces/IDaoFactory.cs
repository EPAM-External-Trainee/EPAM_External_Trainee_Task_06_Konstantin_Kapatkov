using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;

namespace DAL.DAO.Interfaces
{
    /// <summary>Interfaces describes factory to create Dao instances</summary>
    public interface IDaoFactory
    {
        /// <summary>Getting Dao <see cref="Gender"/> object</summary>
        /// <returns><see cref="IDao{Gender}"/> object</returns>
        IDao<Gender> GetGender();

        /// <summary>Getting Dao <see cref="Group"/> object</summary>
        /// <returns><see cref="IDao{Group}"/> object</returns>
        IDao<Group> GetGroup();

        /// <summary>Getting Dao <see cref="KnowledgeAssessmentForm"/> object</summary>
        /// <returns><see cref="IDao{KnowledgeAssessmentForm}"/> object</returns>
        IDao<KnowledgeAssessmentForm> GetKnowledgeAssessmentForm();

        /// <summary>Getting Dao <see cref="Subject"/> object</summary>
        /// <returns><see cref="IDao{Subject}"/> object</returns>
        IDao<Subject> GetSubject();

        /// <summary>Getting Dao <see cref="Student"/> object</summary>
        /// <returns><see cref="IDao{Student}"/> object</returns>
        IDao<Student> GetStudent();

        /// <summary>Getting Dao <see cref="Session"/> object</summary>
        /// <returns><see cref="IDao{Session}"/> object</returns>
        IDao<Session> GetSession();

        /// <summary>Getting Dao <see cref="SessionSchedule"/> object</summary>
        /// <returns><see cref="IDao{SessionSchedule}"/> object</returns>
        IDao<SessionSchedule> GetSessionSchedule();

        /// <summary>Getting Dao <see cref="SessionResult"/> object</summary>
        /// <returns><see cref="IDao{SessionResult}"/> object</returns>
        IDao<SessionResult> GetSessionResult();
    }
}