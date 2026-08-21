using IoTSensorTelemetry.Models;

namespace IoTSensorTelemetry.Repositories;

public sealed class InMemoryKpiRepository : IKpiRepository
{
    private readonly Dictionary<(DateOnly Date, SensorType SensorType), DailyKpi> _store = [];
    private readonly object _lock = new();

    public void Save(DailyKpi kpi)
    {
        lock (_lock)
        {
            _store[(kpi.Date, kpi.SensorType)] = kpi;
        }
    }

    public IReadOnlyList<DailyKpi> GetByDate(DateOnly date)
    {
        lock (_lock)
        {
            return _store
                .Where(x => x.Key.Date == date)
                .Select(x => x.Value)
                .OrderBy(x => x.SensorType)
                .ToList();
        }
    }
}
