using IoTSensorTelemetry.Models;

namespace IoTSensorTelemetry.Repositories;

public interface IKpiRepository
{
    void Save(DailyKpi kpi);
    IReadOnlyList<DailyKpi> GetByDate(DateOnly date);
}
