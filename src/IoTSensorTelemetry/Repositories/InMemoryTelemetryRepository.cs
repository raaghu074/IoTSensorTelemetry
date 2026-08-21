using IoTSensorTelemetry.Models;

namespace IoTSensorTelemetry.Repositories;

public sealed class InMemoryTelemetryRepository : ITelemetryRepository
{
    private readonly List<TelemetryEvent> _events = [];
    private readonly object _lock = new();

    public void Add(TelemetryEvent telemetry)
    {
        lock (_lock)
        {
            _events.Add(telemetry);
        }
    }

    public IReadOnlyList<TelemetryEvent> GetBySensorId(string sensorId)
    {
        lock (_lock)
        {
            return _events
                .Where(x => x.SensorId.Equals(sensorId, StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.Timestamp)
                .ToList();
        }
    }

    public IReadOnlyList<TelemetryEvent> GetByDate(DateOnly date)
    {
        lock (_lock)
        {
            return _events
                .Where(x => DateOnly.FromDateTime(x.Timestamp.UtcDateTime) == date)
                .OrderBy(x => x.Timestamp)
                .ToList();
        }
    }
}
