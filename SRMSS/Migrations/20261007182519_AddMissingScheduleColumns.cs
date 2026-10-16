using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingScheduleColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1));


            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Schedules");


            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Schedules");
        }
    }
}
