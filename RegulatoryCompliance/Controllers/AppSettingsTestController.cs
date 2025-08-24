using Microsoft.AspNetCore.Mvc;
using Common.Interfaces;

namespace RegulatoryCompliance.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class AppSettingsTestController : Controller
    {
        private readonly IAppSettingsService _appSettingsService;
        private readonly Microsoft.ApplicationInsights.TelemetryClient _telemetryClient;

        public AppSettingsTestController(IAppSettingsService appSettingsService, Microsoft.ApplicationInsights.TelemetryClient telemetryClient)
        {
            _appSettingsService = appSettingsService;
            _telemetryClient = telemetryClient;
        }

        [HttpGet("getsettings")]
        public IActionResult GetSettingsTest()
        {
            var appId = _appSettingsService.AppId;
            var appName = _appSettingsService.AppName;

            // Track custom event for settings retrieval
            _telemetryClient.TrackEvent("AppSettingsTestRetrieved");

            // Track custom metric for app name length (example)
            _telemetryClient.TrackMetric("AppNameLength", appName?.Length ?? 0);

            return Ok(new { appId, appName });
        }
    }
}
