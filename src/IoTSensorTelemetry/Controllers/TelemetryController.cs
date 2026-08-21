using IoTSensorTelemetry.DTOs;
using IoTSensorTelemetry.Services;
using Microsoft.AspNetCore.Mvc;

namespace IoTSensorTelemetry.Controllers;

[ApiController]
[Route("api/telemetry")]
public sealed class TelemetryController(ITelemetryService service) : ControllerBase
{
    [HttpPost]
    public ActionResult Create([FromBody] CreateTelemetryRequest request)
    {
        try
        {
            var result = service.Add(request);
            return CreatedAtAction(nameof(GetBySensor), new { sensorId = result.SensorId }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet]
    public ActionResult GetBySensor([FromQuery] string? sensorId)
    {
        if (string.IsNullOrWhiteSpace(sensorId))
            return BadRequest(new { error = "sensorId is required." });

        return Ok(service.GetBySensorId(sensorId));
    }
}
