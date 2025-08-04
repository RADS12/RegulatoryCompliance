using Common.Configuration;
using Common.Enums;
using Common.Models;

namespace RuleEngine.Interfaces
{
    public interface IRegulatoryRuleFacade
    {
        RegulatoryTestType RuleType { get; }
        RegulatoryTestResult RunTest(RegulatoryTestInput input, AppSettingsConfig config);
    }
}
