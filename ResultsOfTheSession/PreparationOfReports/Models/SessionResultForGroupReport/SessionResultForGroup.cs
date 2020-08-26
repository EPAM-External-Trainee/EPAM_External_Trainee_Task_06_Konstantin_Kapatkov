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
        public SessionResultForGroup(string connectionString) : base(connectionString)
        {
        }

        public List<SessionResultForGroupReportData> GetReportData(int sessionId)
        {
            List<SessionResultForGroupReportData> result = new List<SessionResultForGroupReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
            }

            return result;
        }

        public List<SessionResultForGroupReportData> GetReportData(int sessionId, OrderBySessionResultForGroupReport orderBy = OrderBySessionResultForGroupReport.Assessment, bool descendingOrder = false)
        {
            List<SessionResultForGroupReportData> result = new List<SessionResultForGroupReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                switch (orderBy)
                {
                    case OrderBySessionResultForGroupReport.Name:
                        result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = OrderByData(GetRowData(sessionId, groupId), sr => sr.Name, descendingOrder).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
                        break;
                    case OrderBySessionResultForGroupReport.Surname:
                        result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = OrderByData(GetRowData(sessionId, groupId), sr => sr.Surname, descendingOrder).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
                        break;
                    case OrderBySessionResultForGroupReport.Patronymic:
                        result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = OrderByData(GetRowData(sessionId, groupId), sr => sr.Patronymic, descendingOrder).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
                        break;
                    case OrderBySessionResultForGroupReport.Subject:
                        result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = OrderByData(GetRowData(sessionId, groupId), sr => sr.Subject, descendingOrder).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
                        break;
                    case OrderBySessionResultForGroupReport.KnowledgeAssessmentForm:
                        result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = OrderByData(GetRowData(sessionId, groupId), sr => sr.Type, descendingOrder).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
                        break;
                    case OrderBySessionResultForGroupReport.Date:
                        result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = OrderByData(GetRowData(sessionId, groupId), sr => sr.Date, descendingOrder).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
                        break;
                    case OrderBySessionResultForGroupReport.Assessment:
                        if (descendingOrder)
                        {
                            result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderBy(sr => sr.Assessment, new AssessmentComparer()).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
                        }
                        else
                        {
                            result.Add(new SessionResultForGroupReportData { SessionResultForGroupRawViews = GetRowData(sessionId, groupId).OrderByDescending(sr => sr.Assessment, new AssessmentComparer()).ToList(), SessionInfo = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
                        }
                        
                        break;
                }
            }

            return result;
        }

        private IEnumerable<SessionResultForGroupReportRawView> OrderByData(IEnumerable<SessionResultForGroupReportRawView> data, Func<SessionResultForGroupReportRawView, object> predicate, bool isDescOrder) => !isDescOrder ? data.OrderBy(predicate) : data.OrderByDescending(predicate);

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