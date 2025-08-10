using Common.Configuration;
using Common.Enums;
using Common.Models;

namespace RuleEngine.Interfaces
{
    public interface ISafeHarborFacade : IRegulatoryRulesEngine
    {
        RegulatoryTestType RuleType { get; }
        //gulatoryTestResult RunTest(RegulatoryTestInput input, AppSettingsConfig config);

        SafeHarborTestResults RunTest(RegulatoryTestInput input, AppSettingsConfig config);
    }
}
