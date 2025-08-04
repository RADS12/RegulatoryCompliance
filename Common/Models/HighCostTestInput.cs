using Common.Enums;

namespace Common.Models
{
    public class HighCostTestInput : RegulatoryTestInput
    {
        public bool HasBalloonPayment { get; set; }
        public bool HasNegativeAmortization { get; set; }

        public HighCostTestInput()
            : base(RegulatoryTestType.HighCost)
        {
            
        }

        public override bool Validate()
        {
            // Example High Cost validation logic
            if (LoanAmount <= 0 || TermYears <= 0 || InterestRate <= 0)
                return false;

            // High Cost specific checks (example rules)
            if (HasBalloonPayment || HasNegativeAmortization)
                return false; // Suppose High Cost loans can't have these

            // Add more rules as needed
            return true;
        }
    }
}
