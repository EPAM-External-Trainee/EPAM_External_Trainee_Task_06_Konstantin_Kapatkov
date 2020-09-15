using DAL.DAO.Models;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;
using System.Collections.Generic;

namespace BLL.Reports.Interfaces
{
    /// <summary>Interface describes data for report operations</summary>
    public interface IReport
    {
        /// <summary>Dao factory</summary>
        DaoFactory DaoFactory { get; set; }

        /// <summary>Sessions</summary>
        IEnumerable<Session> Sessions { get; set; }

        /// <summary>SessionResults</summary>
        IEnumerable<SessionResult> SessionResults { get; set; }

        /// <summary>SessionSchedules</summary>
        IEnumerable<SessionSchedule> SessionSchedules { get; set; }

        /// <summary>Groups</summary>
        IEnumerable<Group> Groups { get; set; }

        /// <summary>KnowledgeAssessmentForms</summary>
        IEnumerable<KnowledgeAssessmentForm> KnowledgeAssessmentForms { get; set; }

        /// <summary>Students</summary>
        IEnumerable<Student> Students { get; set; }

        /// <summary>Subjects</summary>
        IEnumerable<Subject> Subjects { get; set; }
    }
}