using ResultsOfTheSession.PreparationOfReports.Abstract;
using ResultsOfTheSession.Reports.Comparers;
using ResultsOfTheSession.Reports.Enums;
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
                            select new SessionResultForGroupReportRawView(st.Name, st.Surname, st.Patronymic, s.Name, kaf.Form, ss.Date.ToShortDateString(), sr.Assessment));
            return result;
        }

        private string GetSessionInfo(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId)?.ToString();

        private string GetGroupInfo(int groupId) => Groups.FirstOrDefault(g => g.Id == groupId)?.Name;

        private IEnumerable<SessionResultForGroupReportRawView> OrderByCollection(IEnumerable<SessionResultForGroupReportRawView> collection, Func<SessionResultForGroupReportRawView, object> predicate, bool isDescOrder) => !isDescOrder ? collection.OrderBy(predicate) : collection.OrderByDescending(predicate);

        public IEnumerable<SessionResultForGroupReportData> GetReportData(int sessionId) => SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList().Select(groupId => new SessionResultForGroupReportData(GetRowData(sessionId, groupId), GetSessionInfo(sessionId), GetGroupInfo(groupId)));

        public IEnumerable<SessionResultForGroupReportData> GetReportData(int sessionId, SessionResultForGroupOrderBy orderBy, bool isDescOrder = false)
        {
            List<SessionResultForGroupReportData> result = new List<SessionResultForGroupReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                switch (orderBy)
                {
                    case SessionResultForGroupOrderBy.Name:
                    case SessionResultForGroupOrderBy.Surname:
                    case SessionResultForGroupOrderBy.Patronymic:
                    case SessionResultForGroupOrderBy.Subject:
                    case SessionResultForGroupOrderBy.Date:
                    case SessionResultForGroupOrderBy.Form: result.Add(new SessionResultForGroupReportData(OrderByCollection(GetRowData(sessionId, groupId), s => s.GetType().GetProperty(Enum.GetName(typeof(SessionResultForGroupOrderBy), orderBy)).GetValue(s), isDescOrder), GetSessionInfo(sessionId), GetGroupInfo(groupId))); break;
                    case SessionResultForGroupOrderBy.Assessment:
                        if (isDescOrder)
                        {
                            result.Add(new SessionResultForGroupReportData(GetRowData(sessionId, groupId).OrderBy(s => s.Assessment, new AssessmentComparer(isDescOrder)), GetSessionInfo(sessionId), GetGroupInfo(groupId)));
                        }
                        else
                        {
                            result.Add(new SessionResultForGroupReportData(GetRowData(sessionId, groupId).OrderByDescending(s => s.Assessment, new AssessmentComparer(isDescOrder)), GetSessionInfo(sessionId), GetGroupInfo(groupId)));
                        }
                        break;
                }
            }

            return result;
        }
    }
}