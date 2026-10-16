using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRMSS.Migrations
{
    public partial class AddScheduleStatusOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScheduleStatus",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Scheduled");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleStatus",
                table: "Schedules");
        }
    }
}
