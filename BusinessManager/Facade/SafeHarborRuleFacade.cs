using Common.Configuration;
using Common.Enums;
using Common.Models;
using RuleEngine.Interfaces;

namespace RuleEngine.Facade
{
    public class SafeHarborRuleFacade : IRegulatoryRuleFacade
    {
        //This code should be in separate API running the rules
        //This is a demo for simplicity.
        public RegulatoryTestType RuleType => RegulatoryTestType.SafeHarbor;

        public RegulatoryTestResult RunTest(RegulatoryTestInput input, AppSettingsConfig config)
        {
            var shInput = input as SafeHarborTestInput;
            if (shInput == null)
            {
                return new RegulatoryTestResult
                {
                    TestType = RuleType,
                    IsPassed = false,
                    Message = "Invalid input type for Safe Harbor test."
                };
            }

            bool response = !shInput.HasPrepaymentPenalty;

            return new RegulatoryTestResult
            {
                TestType = RuleType,
                IsPassed = response,
                Message = response ? "Safe Harbor Test Passed" : "Safe Harbor Test Failed"
            };
        }
    }
}
