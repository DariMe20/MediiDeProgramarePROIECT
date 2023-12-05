using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiDeProgramarePROIECT.Migrations
{
    public partial class Schedules2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Table_TableID",
                table: "BookingSchedule");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "BookingSchedule");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "BookingSchedule");

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "BookingSchedule",
                newName: "ScheduleID");

            migrationBuilder.AlterColumn<int>(
                name: "TableID",
                table: "BookingSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_ScheduleID",
                table: "BookingSchedule",
                column: "ScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Schedule_ScheduleID",
                table: "BookingSchedule",
                column: "ScheduleID",
                principalTable: "Schedule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Table_TableID",
                table: "BookingSchedule",
                column: "TableID",
                principalTable: "Table",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Schedule_ScheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Table_TableID",
                table: "BookingSchedule");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_BookingSchedule_ScheduleID",
                table: "BookingSchedule");

            migrationBuilder.RenameColumn(
                name: "ScheduleID",
                table: "BookingSchedule",
                newName: "DayOfWeek");

            migrationBuilder.AlterColumn<int>(
                name: "TableID",
                table: "BookingSchedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "BookingSchedule",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "BookingSchedule",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Table_TableID",
                table: "BookingSchedule",
                column: "TableID",
                principalTable: "Table",
                principalColumn: "ID");
        }
    }
}
