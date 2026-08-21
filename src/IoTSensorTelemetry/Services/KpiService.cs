using IoTSensorTelemetry.Configuration;
using IoTSensorTelemetry.Models;
using IoTSensorTelemetry.Repositories;

namespace IoTSensorTelemetry.Services;

public sealed class KpiService(
    ITelemetryRepository telemetryRepository,
    IKpiRepository kpiRepository) : IKpiService
{
    public IReadOnlyList<DailyKpi> Compute(DateOnly date)
    {
        var telemetry = telemetryRepository.GetByDate(date);

        if (telemetry.Count == 0)
            return [];

        var results = telemetry
            .GroupBy(x => x.SensorType)
            .Select(group =>
            {
                var threshold = SensorRules.Thresholds[group.Key];
                var values = group.Select(x => x.Value).ToList();

                return new DailyKpi
                {
                    Date = date,
                    SensorType = group.Key,
                    HighValueCount = values.Count(value => value > threshold),
                    AverageValue = values.Average()
                };
            })
            .ToList();

        foreach (var kpi in results)
            kpiRepository.Save(kpi);

        return results;
    }

    public IReadOnlyList<DailyKpi> GetByDate(DateOnly date)
        => kpiRepository.GetByDate(date);
}
