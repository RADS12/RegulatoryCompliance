using Common.Enums;

namespace Common.Models
{
    public class RegulatoryTestResult : EntityAuditHistory
    {
        public RegulatoryTestType TestType { get; set; }
        public int LoanNumber { get; set; }
        public bool IsPassed { get; set; }
        public string Message { get; set; }
    }
}
