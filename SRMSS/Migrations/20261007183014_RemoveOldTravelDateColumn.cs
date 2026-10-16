using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRMSS.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldTravelDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'TravelDate'
                )
                ALTER TABLE Schedules DROP COLUMN TravelDate;
            ");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TravelDate",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1));
        }
    }
}
