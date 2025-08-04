using Common.Enums;

namespace Common.Models
{
    public class HighCostTestResult : RegulatoryTestResult
    {
        public HighCostTestResult(long reggieRequestId)
        {
           TestType = RegulatoryTestType.HighCost;
        }
        public int LoanNumber { get; set; }
        public int RegulatoryComplianceId { get; set; }
        public bool PassFedHCFeesTest { get; set; }
        public bool PassFedHCTest { get; set; }
        public bool PassFedYieldComparison { get; set; }
        public bool PassStateHCFeesTest { get; set; }
        public bool PassStateHCTest { get; set; }
        public bool PassStateYieldComparison { get; set; }
    }
}
