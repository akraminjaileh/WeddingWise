using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddPaswored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 434, DateTimeKind.Local).AddTicks(2746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 501, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 433, DateTimeKind.Local).AddTicks(2708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 500, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 413, DateTimeKind.Local).AddTicks(5168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 488, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 418, DateTimeKind.Local).AddTicks(7115),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 491, DateTimeKind.Local).AddTicks(3191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 418, DateTimeKind.Local).AddTicks(734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 490, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 416, DateTimeKind.Local).AddTicks(7168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 490, DateTimeKind.Local).AddTicks(928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 415, DateTimeKind.Local).AddTicks(3017),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 489, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 413, DateTimeKind.Local).AddTicks(9352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 489, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.AddCheckConstraint(
                name: "Ch_User_Password",
                table: "Users",
                sql: "LEN([Password]) > 4\r\n                                   AND PATINDEX('%[A-Z]%', [Password]) > 0\r\n                                   AND PATINDEX('%[a-z]%', [Password]) > 0\r\n                                   AND PATINDEX('%[0-9]%', [Password]) > 0\r\n                                   AND PATINDEX('%[^a-zA-Z0-9]%', [Password]) > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Ch_User_Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 501, DateTimeKind.Local).AddTicks(2002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 434, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 500, DateTimeKind.Local).AddTicks(4160),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 433, DateTimeKind.Local).AddTicks(2708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 488, DateTimeKind.Local).AddTicks(8021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 413, DateTimeKind.Local).AddTicks(5168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 491, DateTimeKind.Local).AddTicks(3191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 418, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 490, DateTimeKind.Local).AddTicks(9300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 418, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 490, DateTimeKind.Local).AddTicks(928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 416, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 489, DateTimeKind.Local).AddTicks(5384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 415, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 489, DateTimeKind.Local).AddTicks(1062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 20, 57, 40, 413, DateTimeKind.Local).AddTicks(9352));
        }
    }
}
