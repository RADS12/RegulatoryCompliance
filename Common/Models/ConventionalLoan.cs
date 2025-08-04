using Common.Enums;

namespace Common.Models
{
    public class ConventionalLoan : LoanBase
    {
        public override string LoanType => LoanTypes.Conventional.ToString();

        public override decimal CalculateMonthlyPayment()
        {
            // Example: Simple fixed-rate payment calculation (for illustration)
            double r = InterestRate / 12.0;
            int n = TermYears * 12;
            double payment = (double)LoanAmount * r / (1 - Math.Pow(1 + r, -n));

            return (decimal)payment;
        }
    }
}