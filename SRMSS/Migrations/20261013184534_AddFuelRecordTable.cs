using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddFuelRecordTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelRecords",
                columns: table => new
                {
                    FuelRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    FuelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuelCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuelStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mileage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelRecords", x => x.FuelRecordId);
                    table.ForeignKey(
                        name: "FK_FuelRecords_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuelRecords_VehicleId",
                table: "FuelRecords",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelRecords");
        }
    }
}
