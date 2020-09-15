using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport;
using System;

namespace BLL.Reports.Excel.Views.GroupSessionResultReport.TableRowViews
{
    /// <summary>Class describing the row view of the group session result table</summary>
    public struct GroupSessionResultTableRowView : IGroupSessionResultTableRowView
    {
        /// <summary>Сreating an instance of <see cref="GroupSessionResultTableRowView"/> via group name, max, min, average assessment</summary>
        /// <param name="groupName">Group name</param>
        /// <param name="maxAssessment">Maximum assessment</param>
        /// <param name="minAssessment">Minimum assessment</param>
        /// <param name="avgAssessment">Average assessment</param>
        public GroupSessionResultTableRowView(string groupName, double maxAssessment, double minAssessment, double avgAssessment)
        {
            GroupName = groupName;
            MaxAssessment = maxAssessment;
            MinAssessment = minAssessment;
            AvgAssessment = avgAssessment;
        }

        /// <inheritdoc cref="IGroupSessionResultTableRowView.GroupName"/>
        public string GroupName { get; set; }

        /// <<inheritdoc cref="IGroupSessionResultTableRowView.MaxAssessment"/>
        public double MaxAssessment { get; set; }

        /// <inheritdoc cref="IGroupSessionResultTableRowView.MinAssessment"/>
        public double MinAssessment { get; set; }

        /// <inheritdoc cref="IGroupSessionResultTableRowView.AvgAssessment"/>
        public double AvgAssessment { get; set; }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override bool Equals(object obj) => obj is GroupSessionResultTableRowView view && GroupName == view.GroupName && MaxAssessment == view.MaxAssessment && MinAssessment == view.MinAssessment && AvgAssessment == view.AvgAssessment;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(GroupName, MaxAssessment, MinAssessment, AvgAssessment);
    }
}