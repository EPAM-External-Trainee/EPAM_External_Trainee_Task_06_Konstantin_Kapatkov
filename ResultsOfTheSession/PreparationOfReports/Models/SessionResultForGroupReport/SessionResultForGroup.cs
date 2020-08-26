using ResultsOfTheSession.PreparationOfReports.Abstract;
using ResultsOfTheSession.PreparationOfReports.Comparers;
using ResultsOfTheSession.PreparationOfReports.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport
{
    public class SessionResultForGroup : Report
    {
        public SessionResultForGroup(string connectionString) : base(connectionString) { }

        public List<SessionResultForGroupReportData> GetReportData(int sessionId)
        {
            List<SessionResultForGroupReportData> result = new List<SessionResultForGroupReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
            }

            return result;
        }

        public SessionResultForGroupReportData GetReportData(int sessionId, int groupId, OrderBy orderBy = OrderBy.Assessment, bool descendingOrder = false)
        {
            return orderBy switch
            {
                OrderBy.Name => new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderBy(r => r.Name).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) },
                OrderBy.Surname => new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderBy(r => r.Surname).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) },
                OrderBy.Patronymic => new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderBy(r => r.Patronymic).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) },
                OrderBy.Subject => new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderBy(r => r.Subject).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) },
                OrderBy.KnowledgeAssessmentForm => new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderBy(r => r.Type).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) },
                OrderBy.Date => new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderBy(r => r.Date).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) },
                OrderBy.Assessment => new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderByDescending(r => r.Assessment, new AssessmentComparer()).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) },
                _ => throw new NotImplementedException(),
            };
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
                            select new SessionResultForGroupReportRawView { Surname = st.Surname, Name = st.Name, Patronymic = st.Patronymic, Subject = s.Name, Type = kaf.Form, Date = ss.Date.ToShortDateString(), Assessment = sr.Assessment });
            return result;
        }

        private string GetSessionInfo(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId).ToString();

        private string GetGroupInfo(int groupId) => Groups.FirstOrDefault(g => g.Id == groupId).Name;
    }
}