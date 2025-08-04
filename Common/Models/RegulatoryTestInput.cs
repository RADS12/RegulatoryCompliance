using Common.Enums;

namespace Common.Models
{
    public abstract class RegulatoryTestInput : EntityAuditHistory
    {
        public RegulatoryTestType TestType { get; }

        public RegulatoryTestInput(RegulatoryTestType testType)
        {
            TestType = testType;
        }

        public long LoanNumber { get; set; }
        public long ReggieRequestId { get; set; }
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public int TermYears { get; set; }

        public abstract bool Validate();
    }
}