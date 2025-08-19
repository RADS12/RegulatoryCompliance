using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class SafeHarborTestInput : RegulatoryTestInput
    {
        public SafeHarborTestInput() : base(RegulatoryTestType.SafeHarbor)
        {
        }

    [Required]
    public int LoanNumber { get; set; }

    [Required]
    public bool HasPrepaymentPenalty { get; set; }

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