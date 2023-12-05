using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiDeProgramarePROIECT.Migrations
{
    public partial class tables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Waiter_WaiterID",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Zone_ZoneID",
                table: "Table");

            migrationBuilder.AlterColumn<int>(
                name: "ZoneID",
                table: "Table",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WaiterID",
                table: "Table",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Waiter_WaiterID",
                table: "Table",
                column: "WaiterID",
                principalTable: "Waiter",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Zone_ZoneID",
                table: "Table",
                column: "ZoneID",
                principalTable: "Zone",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Waiter_WaiterID",
                table: "Table");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Zone_ZoneID",
                table: "Table");

            migrationBuilder.AlterColumn<int>(
                name: "ZoneID",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WaiterID",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Waiter_WaiterID",
                table: "Table",
                column: "WaiterID",
                principalTable: "Waiter",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Zone_ZoneID",
                table: "Table",
                column: "ZoneID",
                principalTable: "Zone",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
