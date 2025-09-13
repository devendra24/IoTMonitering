using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class Telemetries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telemetrys_Devices_DeviceId",
                table: "Telemetrys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telemetrys",
                table: "Telemetrys");

            migrationBuilder.RenameTable(
                name: "Telemetrys",
                newName: "Telemetries");

            migrationBuilder.RenameIndex(
                name: "IX_Telemetrys_DeviceId",
                table: "Telemetries",
                newName: "IX_Telemetries_DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telemetries",
                table: "Telemetries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetries_Devices_DeviceId",
                table: "Telemetries",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telemetries_Devices_DeviceId",
                table: "Telemetries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telemetries",
                table: "Telemetries");

            migrationBuilder.RenameTable(
                name: "Telemetries",
                newName: "Telemetrys");

            migrationBuilder.RenameIndex(
                name: "IX_Telemetries_DeviceId",
                table: "Telemetrys",
                newName: "IX_Telemetrys_DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telemetrys",
                table: "Telemetrys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telemetrys_Devices_DeviceId",
                table: "Telemetrys",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
