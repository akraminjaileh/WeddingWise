using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class RequridPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 548, DateTimeKind.Local).AddTicks(508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 434, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 546, DateTimeKind.Local).AddTicks(5560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 433, DateTimeKind.Local).AddTicks(2708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 531, DateTimeKind.Local).AddTicks(1455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 413, DateTimeKind.Local).AddTicks(5168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 532, DateTimeKind.Local).AddTicks(9101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 418, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 532, DateTimeKind.Local).AddTicks(7118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 418, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 532, DateTimeKind.Local).AddTicks(2117),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 416, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 531, DateTimeKind.Local).AddTicks(7391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 415, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 531, DateTimeKind.Local).AddTicks(3637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 413, DateTimeKind.Local).AddTicks(9352));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 434, DateTimeKind.Local).AddTicks(2746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 548, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 433, DateTimeKind.Local).AddTicks(2708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 546, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 413, DateTimeKind.Local).AddTicks(5168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 531, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 418, DateTimeKind.Local).AddTicks(7115),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 532, DateTimeKind.Local).AddTicks(9101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 418, DateTimeKind.Local).AddTicks(734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 532, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 416, DateTimeKind.Local).AddTicks(7168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 532, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 415, DateTimeKind.Local).AddTicks(3017),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 531, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 413, DateTimeKind.Local).AddTicks(9352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 21, 0, 17, 531, DateTimeKind.Local).AddTicks(3637));
        }
    }
}
