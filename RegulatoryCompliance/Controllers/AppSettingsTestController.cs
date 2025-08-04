using Microsoft.AspNetCore.Mvc;
using Common.Interfaces;

namespace RegulatoryCompliance.Controllers
{
    [ApiController]
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
