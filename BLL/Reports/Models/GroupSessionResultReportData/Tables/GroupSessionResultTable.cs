using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRowViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using BLL.Reports.Interfaces.GroupSessionResultReport;
using BLL.Reports.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models.GroupSessionResultReportData.Tables
{
    /// <summary>Class describing group session result table functionality</summary>
    public class GroupSessionResultTable : Report, IGroupSessionResultTable
    {
        /// <summary>Creating an instance of <see cref="GroupSessionResultTable"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public GroupSessionResultTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>Getting group marks</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="groupId">Group id</param>
        /// <returns><see cref="IEnumerable{double}"/> group marks</returns>
        private IEnumerable<double> GetGroupMarks(int sessionId, int groupId)
        {
            var tmp = SessionResults;
            return from sr in SessionResults
                   join st in Students on sr.StudentId equals st.Id
                   join g in Groups on st.GroupId equals g.Id
                   join ss in SessionSchedules on st.GroupId equals ss.GroupId
                   where g.Id == groupId && ss.KnowledgeAssessmentFormId == 1 && ss.SubjectId == sr.SubjectId && ss.SessionId == sessionId
                   select double.Parse(sr.Assessment);
        }

        /// <summary>Getting row data</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns><see cref="IEnumerable{GroupSessionResultTableRowView}"/> row data</returns>
        private IEnumerable<GroupSessionResultTableRowView> GetRowData(int sessionId)
        {
            List<GroupSessionResultTableRowView> result = new List<GroupSessionResultTableRowView>();
            Dictionary<string, List<double>> tmp = new Dictionary<string, List<double>>();

            foreach (var group in Groups)
            {
                List<double> groupMarks = new List<double>();
                groupMarks.AddRange(GetGroupMarks(sessionId, group.Id));
                tmp.Add(group.Name, groupMarks);
            }

            result.AddRange(tmp.Select(t => new GroupSessionResultTableRowView(t.Key, t.Value.Max(), t.Value.Min(), Math.Round(t.Value.Average(), 1))));
            return result;
        }

        /// <summary>Getting session name</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns>Session name</returns>
        private string GetSessionName(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId)?.Name;

        /// <summary>Getting session academic year</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns>session academic year</returns>
        private string GetSessionAcademicYear(int sessionId) => Sessions.FirstOrDefault(s => s.Id == sessionId)?.AcademicYear;

        /// <inheritdoc cref="IGroupSessionResultTable.GetGroupSessionResultTables"/>
        public IEnumerable<GroupSessionResultTableView> GetGroupSessionResultTables() => Sessions.Select(session => new GroupSessionResultTableView(GetRowData(session.Id), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));

        /// <inheritdoc cref="IGroupSessionResultTable.GetGroupSessionResultTables(Func{GroupSessionResultTableRowView, object}, bool)"/>
        public IEnumerable<GroupSessionResultTableView> GetGroupSessionResultTables(Func<GroupSessionResultTableRowView, object> predicate, bool isDescOrder = false)
        {
            List<GroupSessionResultTableView> result = new List<GroupSessionResultTableView>();
            foreach (var session in Sessions)
            {
                if (isDescOrder)
                {
                    result.Add(new GroupSessionResultTableView(GetRowData(session.Id).OrderByDescending(predicate), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
                }
                else
                {
                    result.Add(new GroupSessionResultTableView(GetRowData(session.Id).OrderBy(predicate), GetSessionName(session.Id), GetSessionAcademicYear(session.Id)));
                }
            }

            return result;
        }
    }
}