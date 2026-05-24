using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECUTelemetryAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelemetryDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RPM = table.Column<int>(type: "int", nullable: false),
                    EngineTemperature = table.Column<int>(type: "int", nullable: false),
                    OilPressure = table.Column<int>(type: "int", nullable: false),
                    BatteryVoltage = table.Column<int>(type: "int", nullable: false),
                    FuelLevel = table.Column<int>(type: "int", nullable: false),
                    TurboPressure = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlarmActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetryDatas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelemetryDatas");
        }
    }
}
