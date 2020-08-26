using ResultsOfTheSession.DAO;
using ResultsOfTheSession.ORM.Models;
using ResultsOfTheSession.ORM.Models.Session;
using System.Collections.Generic;

namespace ResultsOfTheSession.PreparationOfReports.Interfaces
{
    public interface IReport
    {
        DaoFactory DaoFactory { get; set; }

        List<Session> Sessions { get; set; }

        List<SessionResult> SessionResults { get; set; }

        List<SessionSchedule> SessionSchedules { get; set; }

        List<Group> Groups { get; set; }

        List<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        List<Student> Students { get; set; }

        List<Subject> Subjects { get; set; }
    }
}