using ECUTelemetryAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace ECUTelemetryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TelemetryData> TelemetryData { get; set; }
    }
}