using Common.Enums;

namespace Common.Models
{
    public class PointsAndFeesTestInput : RegulatoryTestInput
    {
        // Point & Fees specific properties
        public decimal PointsPaid { get; set; }
        public decimal OtherFees { get; set; }
        public decimal APR { get; set; }

        public PointsAndFeesTestInput()
            : base(RegulatoryTestType.PointsAndFees)
        {
        }

        public override bool Validate()
        {
            // Example Points & Fees validation logic
            if (LoanAmount <= 0 || TermYears <= 0 || InterestRate <= 0)
                return false;

            // Example rule: Points and fees should not exceed a certain percentage of loan amount
            decimal totalFees = PointsPaid + OtherFees;
            decimal maxAllowedFees = LoanAmount * 0.05m; // 5% cap as an example

            if (totalFees > maxAllowedFees)
                return false;

            // Add more Points & Fees rules as needed
            return true;
        }
    }
}
