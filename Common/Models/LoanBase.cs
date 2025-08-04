namespace Common.Models
{
    public abstract class LoanBase : EntityAuditHistory
    {
        public int LoanId { get; set; }
        public long LoanNumber { get; set; }
        public int RegulatoryComplianceId { get; set; }
        public string LoanStatus { get; set; }
        public bool IsQualifiedLoan { get; set; }
        //public int LoanType { get; set; }
        public decimal LoanAmount { get; set; }
        public int TermYears { get; set; }
        public double InterestRate { get; set; }
        public decimal APR { get; set; }
        public DateTime? AnticipatedClosingDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string LienPosition { get; set; }
        public string Occupancy { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyCounty { get; set; }
        public string PropertyState { get; set; }
        public string TitleCompany { get; set; }
        public bool IsHELOC { get; set; }

        public abstract string LoanType { get; }
        public abstract decimal CalculateMonthlyPayment();
        public virtual string GetLoanSummary()
        {
            return $"{LoanType} Loan: Amount={LoanAmount:C}, Rate={InterestRate:P}, Term={TermYears} years";
        }
    }
}
