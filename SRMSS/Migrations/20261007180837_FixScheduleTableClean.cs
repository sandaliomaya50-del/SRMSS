using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRMSS.Migrations
{
    public partial class FixScheduleTableClean : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.Sql(@"
                DECLARE @sql NVARCHAR(MAX) = '';

                SELECT @sql = @sql +
                'ALTER TABLE [' + OBJECT_NAME(parent_object_id) +
                '] DROP CONSTRAINT [' + name + '];'
                FROM sys.foreign_keys
                WHERE parent_object_id = OBJECT_ID('Schedules');

                IF LEN(@sql) > 0
                BEGIN
                    EXEC sp_executesql @sql;
                END
            ");





            migrationBuilder.Sql(@"
                DECLARE @sql NVARCHAR(MAX) = '';

                SELECT @sql = @sql +
                'DROP INDEX [' + name + '] ON [Schedules];'
                FROM sys.indexes
                WHERE object_id = OBJECT_ID('Schedules')
                AND name LIKE 'IX_Schedules_%';

                IF LEN(@sql) > 0
                BEGIN
                    EXEC sp_executesql @sql;
                END
            ");





            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'BusId'
                )
                ALTER TABLE Schedules DROP COLUMN BusId;
            ");





            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'DriverId'
                )
                ALTER TABLE Schedules DROP COLUMN DriverId;
            ");





            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'RouteId'
                )
                ALTER TABLE Schedules DROP COLUMN RouteId;
            ");





            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'ScheduleDate'
                )
                BEGIN
                    EXEC sp_rename 
                    'Schedules.ScheduleDate',
                    'Date',
                    'COLUMN'
                END
            ");





            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'ScheduleId'
                )
                BEGIN
                    EXEC sp_rename 
                    'Schedules.ScheduleId',
                    'Id',
                    'COLUMN'
                END
            ");







            migrationBuilder.AlterColumn<string>(
                name: "DepartureTime",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");







            migrationBuilder.AlterColumn<string>(
                name: "ArrivalTime",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");







            migrationBuilder.Sql(@"
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'Bus'
                )
                ALTER TABLE Schedules
                ADD Bus nvarchar(max) NOT NULL DEFAULT '';
            ");







            migrationBuilder.Sql(@"
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'Driver'
                )
                ALTER TABLE Schedules
                ADD Driver nvarchar(max) NOT NULL DEFAULT '';
            ");







            migrationBuilder.Sql(@"
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'Route'
                )
                ALTER TABLE Schedules
                ADD Route nvarchar(max) NOT NULL DEFAULT '';
            ");





        }





        protected override void Down(MigrationBuilder migrationBuilder)
        {




            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'Bus'
                )
                ALTER TABLE Schedules DROP COLUMN Bus;
            ");






            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'Driver'
                )
                ALTER TABLE Schedules DROP COLUMN Driver;
            ");






            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'Route'
                )
                ALTER TABLE Schedules DROP COLUMN Route;
            ");







            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'Date'
                )
                BEGIN
                    EXEC sp_rename 
                    'Schedules.Date',
                    'ScheduleDate',
                    'COLUMN'
                END
            ");







            migrationBuilder.Sql(@"
                IF EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'Id'
                )
                BEGIN
                    EXEC sp_rename 
                    'Schedules.Id',
                    'ScheduleId',
                    'COLUMN'
                END
            ");






            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DepartureTime",
                table: "Schedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");







            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "Schedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");







            migrationBuilder.Sql(@"
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'BusId'
                )
                ALTER TABLE Schedules
                ADD BusId int NOT NULL DEFAULT 0;
            ");







            migrationBuilder.Sql(@"
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'DriverId'
                )
                ALTER TABLE Schedules
                ADD DriverId int NOT NULL DEFAULT 0;
            ");







            migrationBuilder.Sql(@"
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'RouteId'
                )
                ALTER TABLE Schedules
                ADD RouteId int NOT NULL DEFAULT 0;
            ");







            migrationBuilder.Sql(@"
                IF NOT EXISTS
                (
                    SELECT 1
                    FROM sys.columns
                    WHERE object_id = OBJECT_ID('Schedules')
                    AND name = 'CreatedDate'
                )
                ALTER TABLE Schedules
                ADD CreatedDate datetime2 NOT NULL DEFAULT GETDATE();
            ");





        }

    }

}
