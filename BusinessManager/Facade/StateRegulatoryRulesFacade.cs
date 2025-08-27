using Common.Configuration;
using Common.Enums;
using Common.Models;
using RuleEngine.Interfaces;

namespace RuleEngine.Facade
{
    public class StateRegulatoryRulesFacade : IRegulatoryRuleFacade
    {
        //This code should be in separate API running the rules
        //This is a demo for simplicity.
        public RegulatoryTestType RuleType => RegulatoryTestType.SafeHarbor;

        public RegulatoryTestResult RunTest(RegulatoryTestInput input, AppSettingsConfig config)
        {
            var stateInput = input as StateRegulatoryTestInput;
            if (stateInput == null)
            {
                return new RegulatoryTestResult
                {
                    TestType = RuleType,
                    IsPassed = false,
                    Message = "Invalid input type for State test."
                };
            }

            // Example: State-specific rule, placeholder for more complex logic
            //bool termOk = stateInput.TermYears <= config.MaxLoanTermYears;
            bool stateNotNull = !string.IsNullOrEmpty(stateInput.State);
            //bool passed = termOk && stateNotNull;

            return new RegulatoryTestResult
            {
                TestType = RuleType,
                //IsPassed = passed,
                //Message = passed
                //    ? $"State ({stateInput.State}) Test Passed"
                //    : $"State ({stateInput.State}) Test Failed"
            };
        }
    }
}
