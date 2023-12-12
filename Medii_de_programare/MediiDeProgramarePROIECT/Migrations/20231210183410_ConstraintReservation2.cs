using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiDeProgramarePROIECT.Migrations
{
    public partial class ConstraintReservation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Table_ReservationID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ReservationID",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationID",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationDuration",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservationID",
                table: "Reservation",
                column: "ReservationID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Table_ReservationID",
                table: "Reservation",
                column: "ReservationID",
                principalTable: "Table",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Table_ReservationID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ReservationID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationDuration",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationID",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservationID",
                table: "Reservation",
                column: "ReservationID",
                unique: true,
                filter: "[ReservationID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Table_ReservationID",
                table: "Reservation",
                column: "ReservationID",
                principalTable: "Table",
                principalColumn: "ID");
        }
    }
}
