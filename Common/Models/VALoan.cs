using Common.Enums;

namespace Common.Models
{
    public class VALoan : LoanBase
    {
        public override string LoanType => LoanTypes.VA.ToString();

        public override decimal CalculateMonthlyPayment()
        {
            // Custom logic for VA loans, e.g., no PMI, funding fee, etc.
            double r = InterestRate / 12.0;
            int n = TermYears * 12;
            double payment = (double)LoanAmount * r / (1 - Math.Pow(1 + r, -n));

            // Add VA-specific adjustments if needed
            return (decimal)payment;
        }
    }
}
