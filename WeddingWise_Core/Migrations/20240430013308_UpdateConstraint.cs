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
                name: "CH_ReservationWeddingHall_SweetType",
                table: "ReservationWeddingHalls");

            migrationBuilder.DropCheckConstraint(
                name: "CH_Reservation_NetPrice",
                table: "Reservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 501, DateTimeKind.Local).AddTicks(2002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 438, DateTimeKind.Local).AddTicks(2673));

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "WeddingHalls",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 500, DateTimeKind.Local).AddTicks(4160),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 437, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 488, DateTimeKind.Local).AddTicks(8021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 429, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 491, DateTimeKind.Local).AddTicks(3191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 431, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 106);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 490, DateTimeKind.Local).AddTicks(9300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 431, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Reservations",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 101,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 101,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "NetPrice",
                table: "Reservations",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 490, DateTimeKind.Local).AddTicks(928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 431, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 489, DateTimeKind.Local).AddTicks(5384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 430, DateTimeKind.Local).AddTicks(9572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 489, DateTimeKind.Local).AddTicks(1062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 430, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "CarRentals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 101);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CarRentals",
                type: "int",
                nullable: false,
                defaultValue: 106);

            migrationBuilder.AddCheckConstraint(
                name: "CH_Room_Status",
                table: "Rooms",
                sql: "Status BETWEEN 106 AND 107");

            migrationBuilder.AddCheckConstraint(
                name: "CH_ReservationWeddingHall_SweetType",
                table: "ReservationWeddingHalls",
                sql: "SweetType BETWEEN 101 AND 106");

            migrationBuilder.AddCheckConstraint(
                name: "CH_Reservation_NetPrice",
                table: "Reservations",
                sql: "NetPrice >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CH_CarRental_Status",
                table: "CarRentals",
                sql: "Status BETWEEN 106 AND 107");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CH_Room_Status",
                table: "Rooms");

            migrationBuilder.DropCheckConstraint(
                name: "CH_ReservationWeddingHall_SweetType",
                table: "ReservationWeddingHalls");

            migrationBuilder.DropCheckConstraint(
                name: "CH_Reservation_NetPrice",
                table: "Reservations");

            migrationBuilder.DropCheckConstraint(
                name: "CH_CarRental_Status",
                table: "CarRentals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CarRentals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "WeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 438, DateTimeKind.Local).AddTicks(2673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 501, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "WeddingHalls",
                type: "int",
                nullable: false,
                defaultValue: 101,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 437, DateTimeKind.Local).AddTicks(6430),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 500, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 101,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 429, DateTimeKind.Local).AddTicks(3711),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 488, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 431, DateTimeKind.Local).AddTicks(9044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 491, DateTimeKind.Local).AddTicks(3191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationWeddingHalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 431, DateTimeKind.Local).AddTicks(7274),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 490, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Reservations",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 101);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 101);

            migrationBuilder.AlterColumn<float>(
                name: "NetPrice",
                table: "Reservations",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 431, DateTimeKind.Local).AddTicks(4545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 490, DateTimeKind.Local).AddTicks(928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "ReservationCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 430, DateTimeKind.Local).AddTicks(9572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 489, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "CarRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 2, 15, 51, 430, DateTimeKind.Local).AddTicks(6296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 4, 33, 7, 489, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "CarRentals",
                type: "int",
                nullable: false,
                defaultValue: 101,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddCheckConstraint(
                name: "CH_ReservationWeddingHall_SweetType",
                table: "ReservationWeddingHalls",
                sql: "SweetType BETWEEN 101 AND 104");

            migrationBuilder.AddCheckConstraint(
                name: "CH_Reservation_NetPrice",
                table: "Reservations",
                sql: "NetPrice > 0");
        }
    }
}
