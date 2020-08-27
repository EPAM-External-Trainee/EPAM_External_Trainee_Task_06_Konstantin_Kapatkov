using ResultsOfTheSession.PreparationOfReports.Abstract;
using ResultsOfTheSession.PreparationOfReports.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport
{
    public class SessionResultForGroup : Report
    {
        public SessionResultForGroup(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<SessionResultForGroupReportRawView> GetRowData(int sessionId, int groupId)
        {
            List<SessionResultForGroupReportRawView> result = new List<SessionResultForGroupReportRawView>();
            result.AddRange(from st in Students
                            join sr in SessionResults on st.Id equals sr.StudentId
                            join s in Subjects on sr.SubjectId equals s.Id
                            join ss in SessionSchedules on st.GroupId equals ss.GroupId
                            join kaf in KnowledgeAssessmentForms on ss.KnowledgeAssessmentFormId equals kaf.Id
                            join g in Groups on st.GroupId equals g.Id
                            where ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId && st.GroupId == groupId
                            select new SessionResultForGroupReportRawView(st.Name, st.Surname, st.Patronymic, s.Name, kaf.Form, ss.Date.ToShortDateString(), sr.Assessment ));
            return result;
        }

        private string GetSessionInfo(int sessionId) => Sessions.Find(s => s.Id == sessionId)?.ToString();

        private string GetGroupInfo(int groupId) => Groups.Find(g => g.Id == groupId)?.Name;

        public IEnumerable<SessionResultForGroupReportData> GetReportData(int sessionId)
        {
            List<SessionResultForGroupReportData> result = new List<SessionResultForGroupReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                result.Add(new SessionResultForGroupReportData(GetRowData(sessionId, groupId), GetSessionInfo(sessionId), GetGroupInfo(groupId)));
            }

            return result;
        }

        public IEnumerable<SessionResultForGroupReportData> GetReportData(int sessionId, Func<SessionResultForGroupReportRawView, object> predicate, bool isDescOrder = false)
        {
            List<SessionResultForGroupReportData> result = new List<SessionResultForGroupReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                if (!isDescOrder)
                {
                    result.Add(new SessionResultForGroupReportData(GetRowData(sessionId, groupId).OrderBy(predicate), GetSessionInfo(sessionId), GetGroupInfo(groupId)));
                }
                else
                {
                    result.Add(new SessionResultForGroupReportData(GetRowData(sessionId, groupId).OrderByDescending(predicate), GetSessionInfo(sessionId), GetGroupInfo(groupId)));
                }
            }

            return result;
        }
    }
}