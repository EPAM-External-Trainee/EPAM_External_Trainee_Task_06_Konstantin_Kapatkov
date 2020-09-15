using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using BLL.Reports.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models.ExpelledStudentTable.Tables
{
    public class ExpelledStudentsTable : Report
    {
        public ExpelledStudentsTable(string connectionString) : base(connectionString)
        {
        }

        private IEnumerable<ExpelledStudentsTableRowView> GetRowData(int sessionId, int groupId)
        {
            List<ExpelledStudentsTableRowView> result = new List<ExpelledStudentsTableRowView>();
            foreach (var data in GetStudentsAndAssessments(sessionId, groupId).Distinct())
            {
                double.TryParse(data.Item4, out double assessment);
                if (string.Equals(data.Item4, "not passed", StringComparison.OrdinalIgnoreCase) || (assessment < 5 && assessment != 0))
                {
                    result.Add(new ExpelledStudentsTableRowView(data.Item1, data.Item2, data.Item3));
                }
            }
            return result;
        }

        private IEnumerable<(string, string, string, string)> GetStudentsAndAssessments(int sessionId, int groupId)
        {
            return from sr in SessionResults
                   join st in Students on sr.StudentId equals st.Id
                   join ss in SessionSchedules on sessionId equals ss.SessionId
                   where st.GroupId == groupId && ss.SubjectId == sr.SubjectId
                   select (st.Surname, st.Name, st.Patronymic, sr.Assessment);
        }

        private int[] GetGroupsId(int sessionId) => SessionSchedules.Where(s => s.SessionId == sessionId).Select(s => s.GroupId).Distinct().ToArray();

        private string GetGroupName(int groupId) => Groups.FirstOrDefault(g => g.Id == groupId)?.Name;

        public IEnumerable<ExpelledStudentsTableView> GetReportData(int sessionId) => GetGroupsId(sessionId).Select(groupId => new ExpelledStudentsTableView(GetRowData(sessionId, groupId), GetGroupName(groupId)));

        public IEnumerable<ExpelledStudentsTableView> GetReportData(int sessionId, Func<ExpelledStudentsTableRowView, object> predicate, bool isDescOrder = false)
        {
            return isDescOrder ? GetGroupsId(sessionId).Select(groupId => new ExpelledStudentsTableView(GetRowData(sessionId, groupId).OrderBy(predicate), GetGroupName(groupId))) : GetGroupsId(sessionId).Select(groupId => new ExpelledStudentsTableView(GetRowData(sessionId, groupId).OrderByDescending(predicate), GetGroupName(groupId)));
        }
    }
}