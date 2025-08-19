using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public abstract class RegulatoryTestInput : EntityAuditHistory
    {
        public RegulatoryTestInput(RegulatoryTestType testType)
        {
            TestType = testType;
        }

        public readonly RegulatoryTestType TestType;

    [Required]
    public int LoanNumber { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal LoanAmount { get; set; }

    [Range(0.01, double.MaxValue)]
    public double InterestRate { get; set; }

    [Range(1, int.MaxValue)]
    public int TermYears { get; set; }

        public abstract bool Validate();
    }
}