using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    CurrentMileage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
