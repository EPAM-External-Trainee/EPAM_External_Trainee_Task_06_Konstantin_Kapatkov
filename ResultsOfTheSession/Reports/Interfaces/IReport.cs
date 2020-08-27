using ResultsOfTheSession.DAO;
using ResultsOfTheSession.ORM.Models;
using ResultsOfTheSession.ORM.Models.Session;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Interfaces
{
    public interface IReport
    {
        DaoFactory DaoFactory { get; set; }

        IEnumerable<Session> Sessions { get; set; }

        IEnumerable<SessionResult> SessionResults { get; set; }

        IEnumerable<SessionSchedule> SessionSchedules { get; set; }

        IEnumerable<Group> Groups { get; set; }

        IEnumerable<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        IEnumerable<Student> Students { get; set; }

        IEnumerable<Subject> Subjects { get; set; }
    }
}