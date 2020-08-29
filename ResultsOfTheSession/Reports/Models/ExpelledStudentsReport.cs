using ResultsOfTheSession.PreparationOfReports.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport
{
    public class ExpelledStudentsReport : Report
    {
        public ExpelledStudentsReport(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<ExpelledStudentsReportRawView> GetRowData(int sessionId, int groupId)
        {
            List<ExpelledStudentsReportRawView> result = new List<ExpelledStudentsReportRawView>();

            var query = from sr in SessionResults
                        join st in Students on sr.StudentId equals st.Id
                        join ss in SessionSchedules on sessionId equals ss.SessionId
                        where st.GroupId == groupId && ss.SubjectId == sr.SubjectId
                        select new { st.Surname, st.Name, st.Patronymic, sr.Assessment };

            foreach (var item in query.Distinct())
            {
                double.TryParse(item.Assessment, out double assessment);
                if (item.Assessment == "Not passed" || (assessment < 5 && assessment != 0))
                {
                    result.Add(new ExpelledStudentsReportRawView(item.Name, item.Surname, item.Patronymic));
                }
            }

            return result;
        }

        private string GetAcademicYear(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId).AcademicYear;

        private string GetGroupInfo(int groupId) => Groups.FirstOrDefault(g => g.Id == groupId).Name;

        public IEnumerable<ExpelledStudentsReportData> GetReportData(int sessionId) => SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList().Select(groupId => new ExpelledStudentsReportData(GetRowData(sessionId, groupId).ToList(), GetAcademicYear(sessionId), GetGroupInfo(groupId)));

        public IEnumerable<ExpelledStudentsReportData> GetReportData(int sessionId, Func<ExpelledStudentsReportRawView, object> predicate, bool isDescOrder = false)
        {
            List<ExpelledStudentsReportData> result = new List<ExpelledStudentsReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                if (!isDescOrder)
                {
                    result.Add(new ExpelledStudentsReportData(GetRowData(sessionId, groupId).OrderBy(predicate), GetAcademicYear(sessionId), GetGroupInfo(groupId)));
                }
                else
                {
                    result.Add(new ExpelledStudentsReportData(GetRowData(sessionId, groupId).OrderByDescending(predicate), GetAcademicYear(sessionId), GetGroupInfo(groupId)));
                }
            }
            return result;
        }
    }
}