using Common.Configuration;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using RuleEngine.Interfaces;

namespace RuleEngine.Facade
{
    public abstract class RegulatoryRulesEngine : IRegulatoryRulesEngine
    {
        private readonly Dictionary<RegulatoryTestType, IRegulatoryRuleFacade> _rules;
        private readonly AppSettingsConfig _config;

        public RegulatoryRulesEngine(IEnumerable<IRegulatoryRuleFacade> rules, IAppSettingsService configService)
        {
            _rules = rules.ToDictionary(r => r.RuleType, r => r);
            _config = configService.GetConfig();
        }

        public RegulatoryTestResult RunRegulatoryTests(RegulatoryTestType type, RegulatoryTestInput input)
        {
            if (_rules.TryGetValue(type, out var rule))
                return rule.RunTest(input, _config);

            return new RegulatoryTestResult
            {
                TestType = type,
                IsPassed = false,
                Message = "No rule found for this test type."
            };
        }

        public IEnumerable<RegulatoryTestResult> RunRegulatoryTests(IEnumerable<RegulatoryTestType> types, RegulatoryTestInput input)
        {
            foreach (var type in types)
                yield return RunRegulatoryTests(type, input);
        }
    }
}
