using IoTSensorTelemetry.DTOs;
using IoTSensorTelemetry.Models;
using IoTSensorTelemetry.Repositories;

namespace IoTSensorTelemetry.Services;

public sealed class TelemetryService(ITelemetryRepository repository) : ITelemetryService
{
    public TelemetryEvent Add(CreateTelemetryRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SensorId))
            throw new ArgumentException("sensorId is required.");

        if (!request.SensorType.HasValue || !Enum.IsDefined(request.SensorType.Value))
            throw new ArgumentException("sensorType must be Temperature, Humidity, or Pressure.");

        if (!double.IsFinite(request.Value))
            throw new ArgumentException("value must be a finite numeric value.");

        if (!request.Timestamp.HasValue)
            throw new ArgumentException("timestamp is required.");

        var telemetry = new TelemetryEvent
        {
            SensorId = request.SensorId.Trim(),
            SensorType = request.SensorType.Value,
            Value = request.Value,
            Timestamp = request.Timestamp.Value
        };

        repository.Add(telemetry);
        return telemetry;
    }

    public IReadOnlyList<TelemetryEvent> GetBySensorId(string sensorId)
    {
        if (string.IsNullOrWhiteSpace(sensorId))
            throw new ArgumentException("sensorId is required.");

        return repository.GetBySensorId(sensorId.Trim());
    }
}
