using ECUTelemetryAPI.DTOs;
using ECUTelemetryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECUTelemetryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetryController : ControllerBase
    {
        private readonly ITelemetryService _telemetryService;

        public TelemetryController(ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
        }

        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze(CreateTelemetryDto dto)
        {
            var result = await _telemetryService.AnalyzeTelemetryAsync(dto);

            return Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> History()
        {
            var result = await _telemetryService.GetHistoryAsync();

            return Ok(result);
        }

        [HttpGet("health")]
        public async Task<IActionResult> Health()
        {
            var result = await _telemetryService.GetHealthAsync();

            return Ok(result);
        }
    }
}