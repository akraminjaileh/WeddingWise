using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddIsComletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ReservationWeddingHalls");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "ReservationCars");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ReservationCars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 407, DateTimeKind.Local).AddTicks(2064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 193, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 405, DateTimeKind.Local).AddTicks(1280),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 192, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 391, DateTimeKind.Local).AddTicks(7174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 181, DateTimeKind.Local).AddTicks(8854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 394, DateTimeKind.Local).AddTicks(7031),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 184, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ReservationWeddingHalls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 393, DateTimeKind.Local).AddTicks(3848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 183, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ReservationCars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 392, DateTimeKind.Local).AddTicks(914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 182, DateTimeKind.Local).AddTicks(1929));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ReservationWeddingHalls");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ReservationCars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 193, DateTimeKind.Local).AddTicks(7337),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 407, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 192, DateTimeKind.Local).AddTicks(7855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 405, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 181, DateTimeKind.Local).AddTicks(8854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 391, DateTimeKind.Local).AddTicks(7174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 184, DateTimeKind.Local).AddTicks(9941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 394, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 184, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ReservationWeddingHalls",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 183, DateTimeKind.Local).AddTicks(3170),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 393, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 182, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ReservationCars",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 1, 22, 16, 18, 182, DateTimeKind.Local).AddTicks(1929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 392, DateTimeKind.Local).AddTicks(914));
        }
    }
}
