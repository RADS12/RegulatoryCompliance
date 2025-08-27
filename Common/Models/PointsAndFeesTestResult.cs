using Common.Enums;

namespace Common.Models
{
    public class PointsAndFeesTestOutput : RegulatoryTestResult
    {
        public PointsAndFeesTestOutput()
        {
            TestType = RegulatoryTestType.PointsAndFees;
        }

        //public int LoanNumber { get; set; }
        public int RegulatoryComplianceId { get; set; }

        public decimal AffiliatedAppraisalFeeAmount { get; set; }

        public decimal AffiliatedTitleFeesAmount { get; set; }

        public bool AreQMAffiliatedFeesFinanced { get; set; }
    }
}
