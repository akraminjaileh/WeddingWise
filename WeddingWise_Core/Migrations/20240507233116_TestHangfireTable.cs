using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class TestHangfireTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 874, DateTimeKind.Local).AddTicks(2864),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 407, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 873, DateTimeKind.Local).AddTicks(7830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 405, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 866, DateTimeKind.Local).AddTicks(8651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 391, DateTimeKind.Local).AddTicks(7174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 868, DateTimeKind.Local).AddTicks(5298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 394, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 867, DateTimeKind.Local).AddTicks(8583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 393, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 867, DateTimeKind.Local).AddTicks(1089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 392, DateTimeKind.Local).AddTicks(914));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 407, DateTimeKind.Local).AddTicks(2064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 874, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 405, DateTimeKind.Local).AddTicks(1280),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 873, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 391, DateTimeKind.Local).AddTicks(7174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 866, DateTimeKind.Local).AddTicks(8651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 394, DateTimeKind.Local).AddTicks(7031),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 868, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 393, DateTimeKind.Local).AddTicks(3848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 867, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 1, 18, 3, 392, DateTimeKind.Local).AddTicks(914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 867, DateTimeKind.Local).AddTicks(1089));
        }
    }
}
