using Common.Configuration;
using Common.Enums;
using Common.Models;
using RuleEngine.Interfaces;

namespace RuleEngine.Facade
{
    //This code should be inseperate API running the rules
    //This is a demo for simplicity.
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
            bool response = !hcInput.HasBalloonPayment;
            //bool withinTerm = hcInput.TermYears <= config.MaxLoanTermYears;
            //bool passed = noBalloon && withinTerm;

            return new RegulatoryTestResult
            {
                TestType = RuleType,
                IsPassed = response,
                Message = response ? "High Cost Test Passed" : "High Cost Test Failed"
            };
        }
    }
}
