namespace IoTSensorTelemetry.Models;

public sealed class DailyKpi
{
    public DateOnly Date { get; init; }
    public SensorType SensorType { get; init; }
    public int HighValueCount { get; init; }
    public double AverageValue { get; init; }
}
