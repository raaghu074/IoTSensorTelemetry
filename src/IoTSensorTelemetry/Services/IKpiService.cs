using IoTSensorTelemetry.Models;

namespace IoTSensorTelemetry.Services;

public interface IKpiService
{
    IReadOnlyList<DailyKpi> Compute(DateOnly date);
    IReadOnlyList<DailyKpi> GetByDate(DateOnly date);
}
