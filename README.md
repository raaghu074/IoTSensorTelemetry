# IoT Sensor Telemetry Service

ASP.NET Core REST API for ingesting IoT telemetry, storing it in memory, calculating daily KPIs, and retrieving telemetry/KPI data.

## Stack
- .NET 10
- ASP.NET Core Web API
- C#
- In-memory repositories
- Swagger/OpenAPI
- xUnit

## Architecture
Controller -> Service -> Repository -> In-memory storage

## KPI rules
- Temperature: high when `value > 30`
- Humidity: high when `value > 70`
- Pressure: high when `value > 1000`

## Run

```bash
dotnet restore
dotnet run --project src/IoTSensorTelemetry
```

Open the Swagger URL printed by the application.

## APIs

### Ingest
`POST /api/telemetry`

```json
{
  "sensorId": "TEMP-001",
  "sensorType": "Temperature",
  "value": 32.5,
  "timestamp": "2026-08-21T10:00:00Z"
}
```

### Fetch telemetry
`GET /api/telemetry?sensorId=TEMP-001`

### Compute KPIs
`POST /api/kpis/compute?date=2026-08-21`

### Fetch KPIs
`GET /api/kpis?date=2026-08-21`

### Health
`GET /health`

## Tests

```bash
dotnet test
```


