using IoTSensorTelemetry.DTOs;
using IoTSensorTelemetry.Models;

namespace IoTSensorTelemetry.Services;

public interface ITelemetryService
{
    TelemetryEvent Add(CreateTelemetryRequest request);
    IReadOnlyList<TelemetryEvent> GetBySensorId(string sensorId);
}
