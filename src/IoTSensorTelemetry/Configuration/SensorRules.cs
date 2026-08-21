using IoTSensorTelemetry.Models;

namespace IoTSensorTelemetry.Configuration;

public static class SensorRules
{
    public static readonly IReadOnlyDictionary<SensorType, double> Thresholds =
        new Dictionary<SensorType, double>
        {
            [SensorType.Temperature] = 30,
            [SensorType.Humidity] = 70,
            [SensorType.Pressure] = 1000
        };
}
