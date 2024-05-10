using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CH_AgentTransaction_Status",
                table: "AgentTransactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 553, DateTimeKind.Local).AddTicks(9071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 682, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 553, DateTimeKind.Local).AddTicks(3546),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 681, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 547, DateTimeKind.Local).AddTicks(6284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 674, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 546, DateTimeKind.Local).AddTicks(7610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 673, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 545, DateTimeKind.Local).AddTicks(8036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 672, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AgentTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 545, DateTimeKind.Local).AddTicks(4588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 672, DateTimeKind.Local).AddTicks(6679));

            migrationBuilder.AddCheckConstraint(
                name: "CH_AgentTransaction_Status",
                table: "AgentTransactions",
                sql: "Status = 101 OR Status = 106");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CH_AgentTransaction_Status",
                table: "AgentTransactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 682, DateTimeKind.Local).AddTicks(5188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 553, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 681, DateTimeKind.Local).AddTicks(5860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 553, DateTimeKind.Local).AddTicks(3546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 674, DateTimeKind.Local).AddTicks(6081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 547, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 673, DateTimeKind.Local).AddTicks(8216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 546, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 672, DateTimeKind.Local).AddTicks(9777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 545, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AgentTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 6, 5, 56, 672, DateTimeKind.Local).AddTicks(6679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 18, 25, 21, 545, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.AddCheckConstraint(
                name: "CH_AgentTransaction_Status",
                table: "AgentTransactions",
                sql: "Status = 101 OR Status = 102");
        }
    }
}
