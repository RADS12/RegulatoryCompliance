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

        public AppSettingsTestController(IAppSettingsService appSettingsService)
        {
            _appSettingsService = appSettingsService;
        }

        [HttpGet("getsettings")]
        public IActionResult GetSettingsTest()
        {
            var appId = _appSettingsService.AppId;
            var appName = _appSettingsService.AppName;

            return Ok( new { appId, appName });
        }
    }
}
