using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ResultsOfTheSession.Reports.Comparers
{
    public class AssessmentComparer : IComparer<string>
    {
        private readonly bool _isDescOrder;

        public AssessmentComparer(bool order) => _isDescOrder = order;

        public int Compare([AllowNull] string x, [AllowNull] string y)
        {
            double.TryParse(x, out double tmp1);
            double.TryParse(y, out double tmp2);

            if (_isDescOrder)
            {
                return tmp1 != 0 && tmp2 != 0 ? -tmp1.CompareTo(tmp2) : x.CompareTo(y);
            }
            else
            {
                return tmp1 != 0 && tmp2 != 0 ? -tmp1.CompareTo(tmp2) : -x.CompareTo(y);
            }
        }
    }
}