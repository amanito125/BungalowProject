using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BungalowProject.Data.Migrations
{
    public partial class BungalowProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bungalow_Reservation_ReservationId",
                table: "Bungalow");

            migrationBuilder.AddColumn<int>(
                name: "BungalowId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Bungalow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvalive",
                table: "Bungalow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BungalowId",
                table: "Reservation",
                column: "BungalowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bungalow_Reservation_ReservationId",
                table: "Bungalow",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Bungalow_BungalowId",
                table: "Reservation",
                column: "BungalowId",
                principalTable: "Bungalow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bungalow_Reservation_ReservationId",
                table: "Bungalow");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Bungalow_BungalowId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_BungalowId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "BungalowId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "IsAvalive",
                table: "Bungalow");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "Bungalow",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bungalow_Reservation_ReservationId",
                table: "Bungalow",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
