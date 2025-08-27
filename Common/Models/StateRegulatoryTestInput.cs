using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class StateRegulatoryTestInput : RegulatoryTestInput
    {
        public StateRegulatoryTestInput() : base(RegulatoryTestType.StateRegulatoryTest)
        {
        }

    // [Required]
    // public int LoanNumber { get; set; }

    [Required]
    public required string State { get; set; }

    public decimal? InitialLockDateIndex { get; set; }

    public decimal? ClosingDateIndex { get; set; }

    public string IndexName { get; set; }
        
        public override bool Validate()
        {
            // Implement Safe Harbor-specific validation logic here
            if (LoanAmount <= 0 || TermYears <= 0 || InterestRate <= 0)
                return false;

            // Add more Safe Harbor rules as needed
            return true;
        }
    }
}