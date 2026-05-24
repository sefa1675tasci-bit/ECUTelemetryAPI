using ECUTelemetryAPI.DTOs;
using ECUTelemetryAPI.Models;

namespace ECUTelemetryAPI.Services
{
    public interface ITelemetryService
    {
        Task<TelemetryData> AnalyzeTelemetryAsync(CreateTelemetryDto dto);

        Task<List<TelemetryData>> GetHistoryAsync();

        Task<object> GetHealthAsync();
    }
}