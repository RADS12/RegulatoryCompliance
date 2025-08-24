using Common.Enums;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using RuleEngine.Interfaces;
using System;

namespace RegulatoryCompliance.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class RegulatoryTestController : ControllerBase
    {
        private readonly IRegulatoryRulesEngine _rulesEngine;
        private readonly Microsoft.ApplicationInsights.TelemetryClient _telemetryClient;

        public RegulatoryTestController(IRegulatoryRulesEngine rulesEngine, Microsoft.ApplicationInsights.TelemetryClient telemetryClient)
        {
            _rulesEngine = rulesEngine;
            _telemetryClient = telemetryClient;
        }

        [HttpPost("runregulatorytests")]
        public IActionResult RunTests([FromBody] RegulatoryTestInput input, [FromQuery] RegulatoryTestType[] tests)
        {
            try {
                var results = _rulesEngine.RunRegulatoryTests(tests, input);

                // Track custom metric: number of tests executed
                _telemetryClient.TrackMetric("RegulatoryTestsExecuted", tests.Length);

                // Track custom event: test types executed
                _telemetryClient.TrackEvent("RegulatoryTestsRun", new System.Collections.Generic.Dictionary<string, string>
                {
                    { "TestTypes", string.Join(",", tests) }
                });

                return Ok(results);
            }
            catch (Exception ex)
            {
                // Track exception
                _telemetryClient.TrackException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
