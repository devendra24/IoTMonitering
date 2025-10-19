using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class updatedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeviceType",
                table: "Devices",
                newName: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Devices",
                newName: "DeviceType");
        }
    }
}
