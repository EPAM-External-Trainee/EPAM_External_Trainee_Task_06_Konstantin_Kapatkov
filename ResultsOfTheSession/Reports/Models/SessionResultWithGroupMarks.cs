using ResultsOfTheSession.PreparationOfReports.Abstract;
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

            result.AddRange(tmp.Select(t => new SessionResultWithGroupMarksReportRawView(t.Key, t.Value.Max(), t.Value.Min(), t.Value.Average())));
            return result;
        }

        private string GetSessionName(int sessionId) => Sessions.Find(s => s.Id == sessionId).Name;

        private string GetSessionAcademicYear(int sessionId) => Sessions.Find(s => s.Id == sessionId).AcademicYear;

        public IEnumerable<SessionResultWithGroupMarksReportData> GetReportData()
        {
            List<SessionResultWithGroupMarksReportData> result = new List<SessionResultWithGroupMarksReportData>();

            foreach (var session in Sessions)
            {
                result.Add(new SessionResultWithGroupMarksReportData(GetRowData(session.Id), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
            }

            return result;
        }

        public IEnumerable<SessionResultWithGroupMarksReportData> GetReportData(Func<SessionResultWithGroupMarksReportRawView, object> predicate, bool isDescOrder = false)
        {
            List<SessionResultWithGroupMarksReportData> result = new List<SessionResultWithGroupMarksReportData>();

            foreach (var session in Sessions)
            {
                if (!isDescOrder)
                {
                    result.Add(new SessionResultWithGroupMarksReportData(GetRowData(session.Id).OrderBy(predicate), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
                }
                else
                {
                    result.Add(new SessionResultWithGroupMarksReportData(GetRowData(session.Id).OrderByDescending(predicate), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
                }
            }

            return result;
        }
    }
}