using ResultsOfTheSession.PreparationOfReports.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport
{
    public class SessionResultWithGroupMarks : Report
    {
        public SessionResultWithGroupMarks(string connectionString) : base(connectionString) { }

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

        private string GetSessionInfo(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId).Name;

        public List<SessionResultWithGroupMarksReportData> GetReportData()
        {
            List<SessionResultWithGroupMarksReportData> result = new List<SessionResultWithGroupMarksReportData>();

            foreach (var session in Sessions)
            {
                result.Add(new SessionResultWithGroupMarksReportData { PrepareSessionResultWithGroupMarksRowViews = GetRowData(session.Id).ToList(), SessionName = Sessions.FirstOrDefault(s => s.Id == session.Id).Name, AcademicYear = Sessions.FirstOrDefault(s => s.Id == session.Id).AcademicYear });
            }

            return result;
        }
    }
}