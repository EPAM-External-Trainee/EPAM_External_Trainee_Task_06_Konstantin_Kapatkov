using ResultsOfTheSession.ORM.Models;
using ResultsOfTheSession.ORM.Models.Session;

namespace ResultsOfTheSession.DAO.Interfaces
{
    public interface IDaoFactory
    {
        IDao<Gender> GetGender();

        IDao<Group> GetGroup();

        IDao<KnowledgeAssessmentForm> GetKnowledgeAssessmentForm();

        IDao<Subject> GetSubject();

        IDao<Student> GetStudent();

        IDao<Session> GetSession();

        IDao<SessionSchedule> GetSessionSchedule();

        IDao<SessionResult> GetSessionResult();
    }
}