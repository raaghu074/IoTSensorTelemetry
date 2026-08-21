using System.ComponentModel.DataAnnotations;
using IoTSensorTelemetry.Models;

namespace IoTSensorTelemetry.DTOs;

public sealed class CreateTelemetryRequest
{
    [Required]
    public string? SensorId { get; init; }

    [Required]
    public SensorType? SensorType { get; init; }

    public double Value { get; init; }

    [Required]
    public DateTimeOffset? Timestamp { get; init; }
}
