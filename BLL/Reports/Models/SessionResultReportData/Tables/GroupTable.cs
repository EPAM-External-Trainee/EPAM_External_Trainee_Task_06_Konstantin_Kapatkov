using BLL.Reports.Excel.Views.SessionResultReport.TableRowViews;
using BLL.Reports.Excel.Views.SessionResultReport.TableViews;
using BLL.Reports.Interfaces.SessionResultReport;
using BLL.Reports.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models.SessionResultReportData.Tables
{
    /// <summary>Class describing group table functionality</summary>
    public class GroupTable : Report, IGroupTable
    {
        /// <summary>Creating an instance of <see cref="GroupTable"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public GroupTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>Getting group table rows data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="groupId">Group id</param>
        /// <returns><see cref="IEnumerable{GroupTableRowView}"/> group table rows data</returns>
        private IEnumerable<GroupTableRowView> GetGroupTableRowsData(int sessionId, int groupId)
        {
            return from st in Students
                   join sr in SessionResults on st.Id equals sr.StudentId
                   join s in Subjects on sr.SubjectId equals s.Id
                   join ss in SessionSchedules on st.GroupId equals ss.GroupId
                   join kaf in KnowledgeAssessmentForms on ss.KnowledgeAssessmentFormId equals kaf.Id
                   join g in Groups on st.GroupId equals g.Id
                   where ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId && st.GroupId == groupId
                   select new GroupTableRowView(st.Name, st.Surname, st.Patronymic, s.Name, kaf.Form, ss.Date.ToShortDateString(), sr.Assessment);
        }

        /// <summary>Getting group name</summary>
        /// <param name="groupId">Group id</param>
        /// <returns>group name</returns>
        private string GetGroupName(int groupId) => Groups.FirstOrDefault(g => g.Id == groupId)?.Name;

        /// <summary>Getting session name</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns>session name</returns>
        private string GetSessionName(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId)?.Name;

        /// <inheritdoc cref="IGroupTable.GetGroupTableData(int)"/>
        public IEnumerable<GroupTableView> GetGroupTableData(int sessionId) => SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList().Select(groupId => new GroupTableView(GetGroupTableRowsData(sessionId, groupId), GetGroupName(groupId), GetSessionName(sessionId))).ToList();

        /// <inheritdoc cref="IGroupTable.GetGroupTableData(int, Func{GroupTableRowView, object}, bool)"/>
        public IEnumerable<GroupTableView> GetGroupTableData(int sessionId, Func<GroupTableRowView, object> predicate, bool isDescOrder)
        {
            List<GroupTableView> result = new List<GroupTableView>();
            foreach (int groupId in SessionSchedules.Where(ss => ss.SessionId == sessionId).Select(ss => ss.GroupId).Distinct().ToList())
            {
                if (isDescOrder)
                {
                    result.Add(new GroupTableView(GetGroupTableRowsData(sessionId, groupId).OrderBy(predicate), GetGroupName(groupId), GetSessionName(sessionId)));
                }
                else
                {
                    result.Add(new GroupTableView(GetGroupTableRowsData(sessionId, groupId).OrderByDescending(predicate), GetGroupName(groupId), GetSessionName(sessionId)));
                }
            }
            return result;
        }
    }
}