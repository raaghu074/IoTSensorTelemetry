using IoTSensorTelemetry.Services;
using Microsoft.AspNetCore.Mvc;

namespace IoTSensorTelemetry.Controllers;

[ApiController]
[Route("api/kpis")]
public sealed class KpiController(IKpiService service) : ControllerBase
{
    [HttpPost("compute")]
    public ActionResult Compute([FromQuery] string? date)
    {
        if (!DateOnly.TryParse(date, out var parsedDate))
            return BadRequest(new { error = "date must be a valid date in yyyy-MM-dd format." });

        var result = service.Compute(parsedDate);

        if (result.Count == 0)
            return NotFound(new { message = $"No telemetry found for {parsedDate:yyyy-MM-dd}." });

        return Ok(result);
    }

    [HttpGet]
    public ActionResult GetByDate([FromQuery] string? date)
    {
        if (!DateOnly.TryParse(date, out var parsedDate))
            return BadRequest(new { error = "date must be a valid date in yyyy-MM-dd format." });

        var result = service.GetByDate(parsedDate);

        if (result.Count == 0)
            return NotFound(new { message = $"No KPI found for {parsedDate:yyyy-MM-dd}." });

        return Ok(result);
    }
}
