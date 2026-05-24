namespace ECUTelemetryAPI.Models
{
    public class TelemetryData
    {
        public int Id { get; set; }

        public int Rpm { get; set; }

        public double Temperature { get; set; }

        public double Speed { get; set; }

        public double FuelLevel { get; set; }

        public string Status { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}