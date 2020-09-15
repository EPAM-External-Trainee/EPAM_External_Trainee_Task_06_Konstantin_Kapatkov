using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableRowViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using BLL.Reports.Interfaces.ExpelledStudentsReport;
using BLL.Reports.Models.Abstract;
using DAL.DAO.Models;
using DAL.ORM.Models;
using DAL.ORM.Models.SessionInfo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Models.ExpelledStudentTable.Tables
{
    /// <summary>Class describing expelled students table functionality</summary>
    public class ExpelledStudentsTable : Report, IExpelledStudentsTable
    {
        /// <summary>Creating an instance of <see cref="ExpelledStudentsTable"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public ExpelledStudentsTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>Getting row data</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="groupId">Group id</param>
        /// <returns>Row data</returns>
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

        /// <summary>Getting student SNP and assessment</summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="groupId">Group id</param>
        /// <returns>Student name, surname, patronymic, assessment as tuple</returns>
        private IEnumerable<(string, string, string, string)> GetStudentsAndAssessments(int sessionId, int groupId)
        {
            return from sr in SessionResults
                   join st in Students on sr.StudentId equals st.Id
                   join ss in SessionSchedules on sessionId equals ss.SessionId
                   where st.GroupId == groupId && ss.SubjectId == sr.SubjectId
                   select (st.Surname, st.Name, st.Patronymic, sr.Assessment);
        }

        /// <summary>Getting group id's</summary>
        /// <param name="sessionId">Session id</param>
        /// <returns>Group id's</returns>
        private int[] GetGroupIds(int sessionId) => SessionSchedules.Where(s => s.SessionId == sessionId).Select(s => s.GroupId).Distinct().ToArray();

        /// <summary>Getting group name</summary>
        /// <param name="groupId">Group id</param>
        /// <returns>Group name</returns>
        private string GetGroupName(int groupId) => Groups.FirstOrDefault(g => g.Id == groupId)?.Name;

        /// <inheritdoc cref="IExpelledStudentsTable.GetReportData(int)"/>
        public IEnumerable<ExpelledStudentsTableView> GetReportData(int sessionId) => GetGroupIds(sessionId).Select(groupId => new ExpelledStudentsTableView(GetRowData(sessionId, groupId), GetGroupName(groupId)));

        /// <inheritdoc cref="IExpelledStudentsTable.GetReportData(int, Func{ExpelledStudentsTableRowView, object}, bool)"/>
        public IEnumerable<ExpelledStudentsTableView> GetReportData(int sessionId, Func<ExpelledStudentsTableRowView, object> predicate, bool isDescOrder = false)
        {
            return isDescOrder ? GetGroupIds(sessionId).Select(groupId => new ExpelledStudentsTableView(GetRowData(sessionId, groupId).OrderBy(predicate), GetGroupName(groupId))) : GetGroupIds(sessionId).Select(groupId => new ExpelledStudentsTableView(GetRowData(sessionId, groupId).OrderByDescending(predicate), GetGroupName(groupId)));
        }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj)
        {
            return obj is ExpelledStudentsTable table &&
                   EqualityComparer<DaoFactory>.Default.Equals(DaoFactory, table.DaoFactory) &&
                   Sessions.SequenceEqual(table.Sessions) &&
                   SessionResults.SequenceEqual(table.SessionResults) &&
                   SessionSchedules.SequenceEqual(table.SessionSchedules) &&
                   Groups.SequenceEqual(table.Groups) &&
                   KnowledgeAssessmentForms.SequenceEqual(table.KnowledgeAssessmentForms) &&
                   Students.SequenceEqual(table.Students) &&
                   Subjects.SequenceEqual(table.Subjects);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(DaoFactory, Sessions, SessionResults, SessionSchedules, Groups, KnowledgeAssessmentForms, Students, Subjects);
    }
}