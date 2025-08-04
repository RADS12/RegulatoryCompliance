using Common.Configuration;
using Common.Enums;
using Common.Models;
using RuleEngine.Interfaces;

namespace RuleEngine.Facade
{
    public class PointsAndFeesRuleFacade : IRegulatoryRuleFacade
    {
        public RegulatoryTestType RuleType => RegulatoryTestType.PointsAndFees;

        public RegulatoryTestResult RunTest(RegulatoryTestInput input, AppSettingsConfig config)
        {
            var pfInput = input as PointsAndFeesTestInput;
            if (pfInput == null)
            {
                return new RegulatoryTestResult
                {
                    TestType = RuleType,
                    IsPassed = false,
                    Message = "Invalid input type for Points & Fees test."
                };
            }

            // Example: Points & Fees cannot exceed a percentage of loan amount
            decimal totalFees = pfInput.PointsPaid + pfInput.OtherFees;
            //decimal maxAllowed = pfInput.LoanAmount * config.PointsAndFeesMaxPercentage;
            //bool passed = totalFees <= maxAllowed;

            return new RegulatoryTestResult
            {
                TestType = RuleType,
                //IsPassed = passed,
                //Message = passed
                //    ? "Points & Fees Test Passed"
                //    : $"Points & Fees exceed the allowed maximum ({maxAllowed:C})."
            };
        }
    }
}
