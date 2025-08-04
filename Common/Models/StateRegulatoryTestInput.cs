using Common.Enums;

namespace Common.Models
{
    public class StateRegulatoryTestInput : RegulatoryTestInput
    {
        public StateRegulatoryTestInput() : base(RegulatoryTestType.StateRegulatoryTest)
        {
        }
        public long StateRegulatoryTestInputId { get; set; }
        public new long? ReggieRequestId { get; set; }
        public string State { get; set; }
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