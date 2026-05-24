namespace ECUTelemetryAPI.DTOs
{
    public class CreateTelemetryDto
    {
        public int Rpm { get; set; }

        public int Temperature { get; set; }

        public int Speed { get; set; }

        public int FuelLevel { get; set; }
    }
}