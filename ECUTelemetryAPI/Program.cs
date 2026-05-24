using ECUTelemetryAPI.Data;
using ECUTelemetryAPI.Hubs;
using ECUTelemetryAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// SignalR
builder.Services.AddSignalR();

// Service
builder.Services.AddScoped<ITelemetryService, TelemetryService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Static Files
app.UseDefaultFiles();
app.UseStaticFiles();

// Controllers
app.MapControllers();

// SignalR Hub
app.MapHub<TelemetryHub>("/telemetryHub");

app.UseDeveloperExceptionPage();

app.Run();