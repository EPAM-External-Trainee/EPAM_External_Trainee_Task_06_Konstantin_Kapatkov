using ResultsOfTheSession.PreparationOfReports.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport
{
    public class SessionResultReport : Report
    {
        public SessionResultReport(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<SessionResultReportRawView> GetRowData(int sessionId, int groupId)
        {
            List<SessionResultReportRawView> result = new List<SessionResultReportRawView>();
            result.AddRange(from st in Students
                            join sr in SessionResults on st.Id equals sr.StudentId
                            join s in Subjects on sr.SubjectId equals s.Id
                            join ss in SessionSchedules on st.GroupId equals ss.GroupId
                            join kaf in KnowledgeAssessmentForms on ss.KnowledgeAssessmentFormId equals kaf.Id
                            join g in Groups on st.GroupId equals g.Id
                            where ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId && st.GroupId == groupId
                            select new SessionResultReportRawView(st.Name, st.Surname, st.Patronymic, s.Name, kaf.Form, ss.Date.ToShortDateString(), sr.Assessment));
            return result;
        }

        private string GetSessionInfo(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId)?.ToString();

        private string GetGroupInfo(int groupId) => Groups.FirstOrDefault(g => g.Id == groupId)?.Name;

        public IEnumerable<SessionResultReportData> GetReportData(int sessionId) => SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList().Select(groupId => new SessionResultReportData(GetRowData(sessionId, groupId), GetSessionInfo(sessionId), GetGroupInfo(groupId)));

        public IEnumerable<SessionResultReportData> GetReportData(int sessionId, Func<SessionResultReportRawView, object> predicate, bool isDescOrder = false)
        {
            List<SessionResultReportData> result = new List<SessionResultReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                if (!isDescOrder)
                {
                    result.Add(new SessionResultReportData(GetRowData(sessionId, groupId).OrderBy(predicate), GetSessionInfo(sessionId), GetGroupInfo(groupId)));
                }
                else
                {
                    result.Add(new SessionResultReportData(GetRowData(sessionId, groupId).OrderByDescending(predicate), GetSessionInfo(sessionId), GetGroupInfo(groupId)));
                }
            }

            return result;
        }
    }
}