using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddFkForAgentTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 682, DateTimeKind.Local).AddTicks(5188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 240, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 681, DateTimeKind.Local).AddTicks(5860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 239, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 674, DateTimeKind.Local).AddTicks(6081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 232, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 673, DateTimeKind.Local).AddTicks(8216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 231, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 672, DateTimeKind.Local).AddTicks(9777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 231, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AgentTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 672, DateTimeKind.Local).AddTicks(6679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 230, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.AddColumn<int>(
                name: "ReservationCarId",
                table: "AgentTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationWeddingHallId",
                table: "AgentTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgentTransactions_ReservationCarId",
                table: "AgentTransactions",
                column: "ReservationCarId",
                unique: true,
                filter: "[ReservationCarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AgentTransactions_ReservationWeddingHallId",
                table: "AgentTransactions",
                column: "ReservationWeddingHallId",
                unique: true,
                filter: "[ReservationWeddingHallId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentTransactions_ReservationCars_ReservationCarId",
                table: "AgentTransactions",
                column: "ReservationCarId",
                principalTable: "ReservationCars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentTransactions_ReservationWeddingHalls_ReservationWeddingHallId",
                table: "AgentTransactions",
                column: "ReservationWeddingHallId",
                principalTable: "ReservationWeddingHalls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentTransactions_ReservationCars_ReservationCarId",
                table: "AgentTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_AgentTransactions_ReservationWeddingHalls_ReservationWeddingHallId",
                table: "AgentTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AgentTransactions_ReservationCarId",
                table: "AgentTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AgentTransactions_ReservationWeddingHallId",
                table: "AgentTransactions");

            migrationBuilder.DropColumn(
                name: "ReservationCarId",
                table: "AgentTransactions");

            migrationBuilder.DropColumn(
                name: "ReservationWeddingHallId",
                table: "AgentTransactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 240, DateTimeKind.Local).AddTicks(2390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 682, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 239, DateTimeKind.Local).AddTicks(6841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 681, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 232, DateTimeKind.Local).AddTicks(9775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 674, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 231, DateTimeKind.Local).AddTicks(9323),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 673, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 231, DateTimeKind.Local).AddTicks(541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 672, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AgentTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 230, DateTimeKind.Local).AddTicks(7965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 672, DateTimeKind.Local).AddTicks(6679));
        }
    }
}
