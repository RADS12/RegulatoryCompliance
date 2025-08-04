using Common.Configuration;
using Common.Enums;
using Common.Models;
using RuleEngine.Interfaces;

namespace RuleEngine.Facade
{
    public class SafeHarborRuleFacade : IRegulatoryRuleFacade
    {
        public RegulatoryTestType RuleType => RegulatoryTestType.SafeHarbor;

        public RegulatoryTestResult RunTest(RegulatoryTestInput input, AppSettingsConfig config)
        {
            var shInput = input as SafeHarborTestInput;
            //bool passed = !shInput.HasPrepaymentPenalty && shInput.TermYears <= config.MaxLoanTermYears;

            return new RegulatoryTestResult
            {
                TestType = RuleType,
                //IsPassed = passed,
                //Message = passed ? "Safe Harbor Test Passed" : "Safe Harbor Test Failed"
            };
        }
    }
}
