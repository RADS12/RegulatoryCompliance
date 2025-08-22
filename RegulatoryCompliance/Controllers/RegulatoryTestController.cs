using Common.Enums;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using RuleEngine.Interfaces;
using System;

namespace RegulatoryCompliance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegulatoryTestController : ControllerBase
    {
        private readonly IRegulatoryRulesEngine _rulesEngine;

        public RegulatoryTestController(IRegulatoryRulesEngine rulesEngine)
        {
            _rulesEngine = rulesEngine;
        }

        [HttpPost("runregulatorytests")]
        public IActionResult RunTests([FromBody] RegulatoryTestInput input, [FromQuery] RegulatoryTestType[] tests)
        {
            if (input == null)
                return BadRequest();
            try {
                var results = _rulesEngine.RunRegulatoryTests(tests, input);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
