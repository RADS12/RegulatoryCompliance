using Common.Enums;
using Common.Models;

namespace RuleEngine.Interfaces
{
    public interface IRegulatoryRulesEngine 
    {
        RegulatoryTestResult RunRegulatoryTests(RegulatoryTestType type, RegulatoryTestInput input);
        IEnumerable<RegulatoryTestResult> RunRegulatoryTests(IEnumerable<RegulatoryTestType> types, RegulatoryTestInput input);
    }
}