namespace IoTSensorTelemetry.Models;

public sealed class TelemetryEvent
{
    public string SensorId { get; init; } = string.Empty;
    public SensorType SensorType { get; init; }
    public double Value { get; init; }
    public DateTimeOffset Timestamp { get; init; }
}
