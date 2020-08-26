using ResultsOfTheSession.PreparationOfReports.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport
{
    public class ExpelledStudents : Report
    {
        public ExpelledStudents(string connectionString) : base(connectionString) { }

        public List<ExpelledStudentsReportData> GetReportData(int sessionId)
        {
            List<ExpelledStudentsReportData> result = new List<ExpelledStudentsReportData>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                result.Add(new ExpelledStudentsReportData {  ExpelledStudentsReportRawViews = GetRowData(sessionId, groupId).ToList(), AcademicYear = GetSessionInfo(sessionId), GroupName = GetGroupInfo(groupId) });
            }

            return result;
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
                    result.Add(new ExpelledStudentsReportRawView { Surname = item.Surname, Name = item.Name, Patronymic = item.Patronymic });
                }
            }

            return result;
        }

        private string GetSessionInfo(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId).AcademicYear;

        private string GetGroupInfo(int groupId) => Groups.FirstOrDefault(g => g.Id == groupId).Name;
    }
}