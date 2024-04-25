using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CH_CarRental_Brand",
                table: "CarRentals");

            migrationBuilder.DropCheckConstraint(
                name: "CH_CarRental_Title",
                table: "CarRentals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 727, DateTimeKind.Local).AddTicks(1229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 268, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 726, DateTimeKind.Local).AddTicks(6724),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 720, DateTimeKind.Local).AddTicks(2109),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 261, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 726, DateTimeKind.Local).AddTicks(4519),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 726, DateTimeKind.Local).AddTicks(1366),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 725, DateTimeKind.Local).AddTicks(8350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 725, DateTimeKind.Local).AddTicks(5016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 266, DateTimeKind.Local).AddTicks(5679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 721, DateTimeKind.Local).AddTicks(6414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 263, DateTimeKind.Local).AddTicks(642));

            migrationBuilder.AddCheckConstraint(
                name: "CH_CarRental_Brand",
                table: "CarRentals",
                sql: "LEN(Brand) >= 3");

            migrationBuilder.AddCheckConstraint(
                name: "CH_CarRental_Title",
                table: "CarRentals",
                sql: "LEN(Title) >= 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CH_CarRental_Brand",
                table: "CarRentals");

            migrationBuilder.DropCheckConstraint(
                name: "CH_CarRental_Title",
                table: "CarRentals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 268, DateTimeKind.Local).AddTicks(4807),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 727, DateTimeKind.Local).AddTicks(1229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(9396),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 726, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 261, DateTimeKind.Local).AddTicks(8617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 720, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(7054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 726, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(3448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 726, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(200),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 725, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 266, DateTimeKind.Local).AddTicks(5679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 725, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 263, DateTimeKind.Local).AddTicks(642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 0, 52, 18, 721, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.AddCheckConstraint(
                name: "CH_CarRental_Brand",
                table: "CarRentals",
                sql: "LEN(Brand) > 3");

            migrationBuilder.AddCheckConstraint(
                name: "CH_CarRental_Title",
                table: "CarRentals",
                sql: "LEN(Title) > 3");
        }
    }
}
