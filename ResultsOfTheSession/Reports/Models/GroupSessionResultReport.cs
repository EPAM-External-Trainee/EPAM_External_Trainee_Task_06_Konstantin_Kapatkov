using ResultsOfTheSession.PreparationOfReports.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport
{
    public class GroupSessionResultReport : Report
    {
        public GroupSessionResultReport(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<GroupSessionResultReportRawView> GetRowData(int sessionId)
        {
            List<GroupSessionResultReportRawView> result = new List<GroupSessionResultReportRawView>();
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

            result.AddRange(tmp.Select(t => new GroupSessionResultReportRawView(t.Key, t.Value.Max(), t.Value.Min(), Math.Round(t.Value.Average(), 1))));
            return result;
        }

        private string GetSessionName(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId).Name;

        private string GetSessionAcademicYear(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId).AcademicYear;

        public IEnumerable<GroupSessionResultReportData> GetReportData() => Sessions.Select(session => new GroupSessionResultReportData(GetRowData(session.Id), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));

        public IEnumerable<GroupSessionResultReportData> GetReportData(Func<GroupSessionResultReportRawView, object> predicate, bool isDescOrder = false)
        {
            List<GroupSessionResultReportData> result = new List<GroupSessionResultReportData>();

            foreach (var session in Sessions)
            {
                if (!isDescOrder)
                {
                    result.Add(new GroupSessionResultReportData(GetRowData(session.Id).OrderBy(predicate), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
                }
                else
                {
                    result.Add(new GroupSessionResultReportData(GetRowData(session.Id).OrderByDescending(predicate), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
                }
            }

            return result;
        }
    }
}