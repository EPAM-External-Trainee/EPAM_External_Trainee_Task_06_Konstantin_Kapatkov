using ResultsOfTheSession.PreparationOfReports.Abstract;
using ResultsOfTheSession.PreparationOfReports.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport
{
    public class SessionResultWithGroupMarks : Report
    {
        public SessionResultWithGroupMarks(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<SessionResultWithGroupMarksReportRawView> GetRowData(int sessionId)
        {
            List<SessionResultWithGroupMarksReportRawView> result = new List<SessionResultWithGroupMarksReportRawView>();
            Dictionary<string, List<double>> tmp = new Dictionary<string, List<double>>();

            foreach (var myGroup in Groups)
            {
                List<double> groupMarks = new List<double>();
                groupMarks.AddRange(from sr in SessionResults
                                    join st in Students on sr.StudentId equals st.Id
                                    join g in Groups on st.GroupId equals g.Id
                                    join ss in SessionSchedules on st.GroupId equals ss.GroupId
                                    where g.Name == myGroup.Name && ss.KnowledgeAssessmentFormId == 1 && ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId
                                    select double.Parse(sr.Assessment));

                tmp.Add(myGroup.Name, groupMarks);
            }

            result.AddRange(tmp.Select(t => new SessionResultWithGroupMarksReportRawView { GroupName = t.Key, MaxAssessment = t.Value.Max(), MinAssessment = t.Value.Min(), AvgAssessment = t.Value.Average() }));
            return result;
        }

        private IEnumerable<SessionResultWithGroupMarksReportRawView> OrderByData(IEnumerable<SessionResultWithGroupMarksReportRawView> data, Func<SessionResultWithGroupMarksReportRawView, object> predicate, bool isDescOrder) => !isDescOrder ? data.OrderBy(predicate) : data.OrderByDescending(predicate);

        private string GetSessionName(int sessionId) => Sessions.Find(s => s.Id == sessionId).Name;

        private string GetSessionAcademicYear(int sessionId) => Sessions.Find(s => s.Id == sessionId).AcademicYear;

        public IEnumerable<SessionResultWithGroupMarksReportData> GetReportData()
        {
            List<SessionResultWithGroupMarksReportData> result = new List<SessionResultWithGroupMarksReportData>();

            foreach (var session in Sessions)
            {
                result.Add(new SessionResultWithGroupMarksReportData { SessionResultWithGroupMarksRowViews = GetRowData(session.Id).ToList(), SessionName = Sessions.Find(s => s.Id == session.Id).Name, AcademicYear = Sessions.Find(s => s.Id == session.Id).AcademicYear });
            }

            return result;
        }

        public IEnumerable<SessionResultWithGroupMarksReportData> GetReportData(SessionResultWithGroupMarksReportOrderBy orderBy, bool descendingOrder = false)
        {
            List<SessionResultWithGroupMarksReportData> result = new List<SessionResultWithGroupMarksReportData>();

            foreach (var session in Sessions)
            {
                switch (orderBy)
                {
                    case SessionResultWithGroupMarksReportOrderBy.GroupName:
                        result.Add(new SessionResultWithGroupMarksReportData { SessionResultWithGroupMarksRowViews = OrderByData(GetRowData(session.Id), sr => sr.GroupName, descendingOrder).ToList(), SessionName = GetSessionName(session.Id), AcademicYear = GetSessionAcademicYear(session.Id) });
                        break;
                    case SessionResultWithGroupMarksReportOrderBy.MaxAssessment:
                        result.Add(new SessionResultWithGroupMarksReportData { SessionResultWithGroupMarksRowViews = OrderByData(GetRowData(session.Id), sr => sr.MaxAssessment, descendingOrder).ToList(), SessionName = GetSessionName(session.Id), AcademicYear = GetSessionAcademicYear(session.Id) });
                        break;
                    case SessionResultWithGroupMarksReportOrderBy.MinAssessment:
                        result.Add(new SessionResultWithGroupMarksReportData { SessionResultWithGroupMarksRowViews = OrderByData(GetRowData(session.Id), sr => sr.MinAssessment, descendingOrder).ToList(), SessionName = GetSessionName(session.Id), AcademicYear = GetSessionAcademicYear(session.Id) });
                        break;
                    case SessionResultWithGroupMarksReportOrderBy.AverageAssessment:
                        result.Add(new SessionResultWithGroupMarksReportData { SessionResultWithGroupMarksRowViews = OrderByData(GetRowData(session.Id), sr => sr.AvgAssessment, descendingOrder).ToList(), SessionName = GetSessionName(session.Id), AcademicYear = GetSessionAcademicYear(session.Id) });
                        break;
                }
            }

            return result;
        }
    }
}