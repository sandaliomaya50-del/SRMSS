using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRMSS.Migrations
{
    /// <inheritdoc />
    public partial class AddDriverFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedRoute",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DriverImage",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingHours",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedRoute",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverImage",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "Drivers");
        }
    }
}
