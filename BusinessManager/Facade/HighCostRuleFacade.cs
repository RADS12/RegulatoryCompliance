using Common.Configuration;
using Common.Enums;
using Common.Models;
using RuleEngine.Interfaces;

namespace RuleEngine.Facade
{
    public class HighCostRuleFacade : IRegulatoryRuleFacade
    {
        public RegulatoryTestType RuleType => RegulatoryTestType.HighCost;

        public RegulatoryTestResult RunTest(RegulatoryTestInput input, AppSettingsConfig config)
        {
            var hcInput = input as HighCostTestInput;
            if (hcInput == null)
            {
                return new RegulatoryTestResult
                {
                    TestType = RuleType,
                    IsPassed = false,
                    Message = "Invalid input type for High Cost test."
                };
            }

            // Example business rules
            bool noBalloon = !hcInput.HasBalloonPayment;
            //bool withinTerm = hcInput.TermYears <= config.MaxLoanTermYears;
            //bool passed = noBalloon && withinTerm;

            return new RegulatoryTestResult
            {
                TestType = RuleType,
                //IsPassed = passed,
                //Message = passed ? "High Cost Test Passed" : "High Cost Test Failed"
            };
        }
    }
}
