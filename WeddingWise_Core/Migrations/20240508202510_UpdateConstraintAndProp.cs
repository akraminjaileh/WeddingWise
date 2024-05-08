using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConstraintAndProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropCheckConstraint(
                name: "CH_AgentTransaction_Balance",
                table: "Transactions");

            migrationBuilder.DropCheckConstraint(
                name: "CH_AgentTransaction_Fees",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "AgentTransactions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AgentTransactions",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_UserId",
                table: "AgentTransactions",
                newName: "IX_AgentTransactions_AgentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 240, DateTimeKind.Local).AddTicks(2390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 874, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 239, DateTimeKind.Local).AddTicks(6841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 873, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 232, DateTimeKind.Local).AddTicks(9775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 868, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 231, DateTimeKind.Local).AddTicks(9323),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 867, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 231, DateTimeKind.Local).AddTicks(541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 867, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.AlterColumn<float>(
                name: "Fees",
                table: "AgentTransactions",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AgentTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 230, DateTimeKind.Local).AddTicks(7965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 866, DateTimeKind.Local).AddTicks(8651));

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "AgentTransactions",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<float>(
                name: "TotalAmount",
                table: "AgentTransactions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentTransactions",
                table: "AgentTransactions",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "CH_AgentTransaction_TotalAmount",
                table: "AgentTransactions",
                sql: "TotalAmount >= 0");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentTransactions_Users_AgentId",
                table: "AgentTransactions",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentTransactions_Users_AgentId",
                table: "AgentTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentTransactions",
                table: "AgentTransactions");

            migrationBuilder.DropCheckConstraint(
                name: "CH_AgentTransaction_TotalAmount",
                table: "AgentTransactions");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "AgentTransactions");

            migrationBuilder.RenameTable(
                name: "AgentTransactions",
                newName: "Transactions");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Transactions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AgentTransactions_AgentId",
                table: "Transactions",
                newName: "IX_Transactions_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 874, DateTimeKind.Local).AddTicks(2864),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 240, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 873, DateTimeKind.Local).AddTicks(7830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 239, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 868, DateTimeKind.Local).AddTicks(5298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 232, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 867, DateTimeKind.Local).AddTicks(8583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 231, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 867, DateTimeKind.Local).AddTicks(1089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 231, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.AlterColumn<decimal>(
                name: "Fees",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 2, 31, 15, 866, DateTimeKind.Local).AddTicks(8651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 23, 25, 10, 230, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "CH_AgentTransaction_Balance",
                table: "Transactions",
                sql: "Balance >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CH_AgentTransaction_Fees",
                table: "Transactions",
                sql: "Fees >= 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
