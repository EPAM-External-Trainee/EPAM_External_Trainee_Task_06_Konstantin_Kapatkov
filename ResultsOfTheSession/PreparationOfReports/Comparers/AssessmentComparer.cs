using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ResultsOfTheSession.PreparationOfReports.Comparers
{
    public class AssessmentComparer : IComparer<string>
    {
        public int Compare([AllowNull] string x, [AllowNull] string y) => double.TryParse(x, out double firstValue) && double.TryParse(y, out double secondValue) ? firstValue.CompareTo(secondValue) : x.CompareTo(y);
    }
}