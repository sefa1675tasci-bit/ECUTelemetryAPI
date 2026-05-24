using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECUTelemetryAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TelemetryDatas",
                table: "TelemetryDatas");

            migrationBuilder.DropColumn(
                name: "AlarmActive",
                table: "TelemetryDatas");

            migrationBuilder.DropColumn(
                name: "BatteryVoltage",
                table: "TelemetryDatas");

            migrationBuilder.DropColumn(
                name: "EngineTemperature",
                table: "TelemetryDatas");

            migrationBuilder.DropColumn(
                name: "OilPressure",
                table: "TelemetryDatas");

            migrationBuilder.DropColumn(
                name: "TurboPressure",
                table: "TelemetryDatas");

            migrationBuilder.RenameTable(
                name: "TelemetryDatas",
                newName: "TelemetryData");

            migrationBuilder.RenameColumn(
                name: "RPM",
                table: "TelemetryData",
                newName: "Rpm");

            migrationBuilder.AlterColumn<double>(
                name: "FuelLevel",
                table: "TelemetryData",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TelemetryData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Speed",
                table: "TelemetryData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Temperature",
                table: "TelemetryData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TelemetryData",
                table: "TelemetryData",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TelemetryData",
                table: "TelemetryData");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TelemetryData");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "TelemetryData");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "TelemetryData");

            migrationBuilder.RenameTable(
                name: "TelemetryData",
                newName: "TelemetryDatas");

            migrationBuilder.RenameColumn(
                name: "Rpm",
                table: "TelemetryDatas",
                newName: "RPM");

            migrationBuilder.AlterColumn<int>(
                name: "FuelLevel",
                table: "TelemetryDatas",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<bool>(
                name: "AlarmActive",
                table: "TelemetryDatas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BatteryVoltage",
                table: "TelemetryDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EngineTemperature",
                table: "TelemetryDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OilPressure",
                table: "TelemetryDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurboPressure",
                table: "TelemetryDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TelemetryDatas",
                table: "TelemetryDatas",
                column: "Id");
        }
    }
}
