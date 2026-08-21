using IoTSensorTelemetry.Models;

namespace IoTSensorTelemetry.Repositories;

public interface ITelemetryRepository
{
    void Add(TelemetryEvent telemetry);
    IReadOnlyList<TelemetryEvent> GetBySensorId(string sensorId);
    IReadOnlyList<TelemetryEvent> GetByDate(DateOnly date);
}
