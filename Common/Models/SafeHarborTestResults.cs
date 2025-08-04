using Common.Enums;

namespace Common.Models
{
    public class SafeHarborTestResults : RegulatoryTestResult
    {
        public SafeHarborTestResults()
        {
            TestType = RegulatoryTestType.SafeHarbor;
        }
        public int LoanNumber { get; set; }
        public int RegulatoryComplianceId { get; set; }

        public bool DoesPassSafeHarborTest;

        public decimal MaximumAPRForSafeHarbor;

        public decimal TotalFeesToBeRecouped;

        public bool SafeHarborSeasonRequirementMet;
    }
}
