using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiDeProgramarePROIECT.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Waiter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    WaiterID = table.Column<int>(type: "int", nullable: false),
                    ZoneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Table_Waiter_WaiterID",
                        column: x => x.WaiterID,
                        principalTable: "Waiter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Table_Zone_ZoneID",
                        column: x => x.ZoneID,
                        principalTable: "Zone",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingSchedule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSchedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookingSchedule_Table_TableID",
                        column: x => x.TableID,
                        principalTable: "Table",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_TableID",
                table: "BookingSchedule",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_Table_WaiterID",
                table: "Table",
                column: "WaiterID");

            migrationBuilder.CreateIndex(
                name: "IX_Table_ZoneID",
                table: "Table",
                column: "ZoneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSchedule");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Waiter");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
