using Common.Enums;

namespace Common.Models
{
    public abstract class RegulatoryTestInput : EntityAuditHistory
    {
        public RegulatoryTestInput(RegulatoryTestType testType)
        {
            TestType = testType;
        }

        public readonly RegulatoryTestType TestType;

        public int LoanNumber { get; set; }
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public int TermYears { get; set; }

        public abstract bool Validate();
    }
}