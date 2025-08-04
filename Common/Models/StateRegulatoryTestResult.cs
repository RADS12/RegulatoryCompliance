using Common.Enums;

namespace Common.Models
{
    public class StateRegulatoryTestResult : RegulatoryTestResult
    {
        public StateRegulatoryTestResult()
        {
            TestType = RegulatoryTestType.StateRegulatoryTest;
        }
        public long StateRegulatoryTestResultId { get; set; }
        public new long? ReggieRequestId { get; set; }
        public long StateRegulatoryTestInputId { get; set; }
        public int StateRegulatoryTestId { get; set; }
        public string StateRegulatoryTestName { get; set; }
        
        public bool DoesTestApply { get; set; }
        public bool DoesPassStateRegulatoryTest { get; set; }
        public string ErrorMessage { get; set; }
    }
}
