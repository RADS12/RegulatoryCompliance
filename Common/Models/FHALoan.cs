using Common.Enums;

namespace Common.Models
{
    public class FHALoan : Loan
    {
        public override string LoanType => LoanTypes.FHA.ToString();

        public override decimal CalculateMonthlyPayment()
        {
            // Custom logic for FHA loans, e.g., different PMI, etc.
            double r = InterestRate / 12.0;
            int n = TermYears * 12;
            double payment = (double)LoanAmount * r / (1 - Math.Pow(1 + r, -n));

            // Add FHA-specific fees if needed
            return (decimal)payment;
        }
    }
}
