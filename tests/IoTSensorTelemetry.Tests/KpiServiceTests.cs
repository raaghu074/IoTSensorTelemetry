using System;
using IoTSensorTelemetry.Models;
using IoTSensorTelemetry.Repositories;
using IoTSensorTelemetry.Services;
using Xunit;

namespace IoTSensorTelemetry.Tests;

public class KpiServiceTests
{
    [Fact]
    public void Temperature_IsNotHigh()
    {
        var telemetryRepository = new InMemoryTelemetryRepository();
        var kpiRepository = new InMemoryKpiRepository();
        var service = new KpiService(telemetryRepository, kpiRepository);

        telemetryRepository.Add(new TelemetryEvent
        {
            SensorId = "TEMP-001",
            SensorType = SensorType.Temperature,
            Value = 30,
            Timestamp = new DateTimeOffset(2026, 8, 21, 10, 0, 0, TimeSpan.Zero)
        });

        var result = service.Compute(new DateOnly(2026, 8, 21));

        Assert.Single(result);
        Assert.Equal(0, result[0].HighValueCount);
        Assert.Equal(30, result[0].AverageValue);
    }
}
