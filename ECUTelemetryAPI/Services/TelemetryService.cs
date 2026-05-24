using ECUTelemetryAPI.Data;
using ECUTelemetryAPI.DTOs;
using ECUTelemetryAPI.Hubs;
using ECUTelemetryAPI.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ECUTelemetryAPI.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<TelemetryHub> _hubContext;

        public TelemetryService(
            AppDbContext context,
            IHubContext<TelemetryHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<TelemetryData> AnalyzeTelemetryAsync(CreateTelemetryDto dto)
        {
            string status = "Normal";

            if (dto.Temperature > 90)
            {
                status = "Warning";
            }

            var telemetry = new TelemetryData
            {
                Rpm = dto.Rpm,
                Temperature = dto.Temperature,
                Speed = dto.Speed,
                FuelLevel = dto.FuelLevel,
                Status = status,
                CreatedAt = DateTime.Now
            };

            // DATABASE KAYIT
            _context.TelemetryData.Add(telemetry);

            await _context.SaveChangesAsync();

            // SIGNALR GÖNDERİMİ
            // ŞİMDİLİK KAPALI TUT
            
            await _hubContext.Clients.All.SendAsync(
                "ReceiveTelemetry",
                telemetry
            );
            

            return telemetry;
        }

        public async Task<List<TelemetryData>> GetHistoryAsync()
        {
            return await _context.TelemetryData
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<object> GetHealthAsync()
        {
            var total = await _context.TelemetryData.CountAsync();

            return new
            {
                Status = "System OK",
                TotalRecords = total,
                Time = DateTime.Now
            };
        }
    }
}