using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<int>(type: "int", nullable: false, defaultValue: 101),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(9396))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CH_User_Birthday", "DATEADD(YEAR, 16, Birthday) <= SYSDATETIME()");
                    table.CheckConstraint("CH_User_City", "City BETWEEN 101 AND 104");
                    table.CheckConstraint("CH_User_Email", "Email Like '%@gmail.com' Or Email Like '%@outlook.com' or Email Like '%@yahoo.com'");
                    table.CheckConstraint("CH_User_Name", "Name NOT LIKE '%[^a-zA-Z ]%' AND LEN(Name) > 5");
                    table.CheckConstraint("Ch_User_NationalNo", "LEN(NationalNo)=10");
                    table.CheckConstraint("Ch_User_phone", "LEN(Phone)=10 AND (Phone LIKE '079%' OR Phone LIKE '078%' OR Phone LIKE '077%')");
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Modal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<int>(type: "int", nullable: false, defaultValue: 101),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PricePerHour = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 263, DateTimeKind.Local).AddTicks(642))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.Id);
                    table.CheckConstraint("CH_CarRental_Brand", "LEN(Brand) > 3");
                    table.CheckConstraint("CH_CarRental_City", "City BETWEEN 101 AND 104");
                    table.CheckConstraint("CH_CarRental_PricePerHour", "PricePerHour > 0");
                    table.CheckConstraint("CH_CarRental_Title", "LEN(Title) > 3");
                    table.CheckConstraint("Ch_CarRental_Year", "Year < SYSDATETIME()");
                    table.ForeignKey(
                        name: "FK_CarRentals_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PromoCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NetPrice = table.Column<float>(type: "real", nullable: false),
                    TaxAmount = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    DiscountAmount = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(200))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.CheckConstraint("CH_Reservation_NetPrice", "NetPrice > 0");
                    table.CheckConstraint("CH_Reservation_PaymentMethod", "PaymentMethod BETWEEN 101 AND 103");
                    table.CheckConstraint("CH_Reservation_Status", "Status BETWEEN 101 AND 105");
                    table.CheckConstraint("CH_Reservation_TotalPrice", "TotalPrice >= NetPrice");
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 101),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 261, DateTimeKind.Local).AddTicks(8617))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.CheckConstraint("CH_AgentTransaction_Balance", "Balance >= 0");
                    table.CheckConstraint("CH_AgentTransaction_Fees", "Fees >= 0");
                    table.CheckConstraint("CH_AgentTransaction_Status", "Status = 101 OR Status = 102");
                    table.CheckConstraint("CH_AgentTransaction_TransactionType", "TransactionType BETWEEN 101 AND 102");
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeddingHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<int>(type: "int", nullable: false, defaultValue: 101),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 268, DateTimeKind.Local).AddTicks(4807))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingHalls", x => x.Id);
                    table.CheckConstraint("CH_WeddingHall_City", "City BETWEEN 101 AND 104");
                    table.CheckConstraint("CH_WeddingHall_Title", "LEN(Title) > 3");
                    table.ForeignKey(
                        name: "FK_WeddingHalls_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeddingHalls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservationCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CarRentalId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 266, DateTimeKind.Local).AddTicks(5679))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationCars", x => x.Id);
                    table.CheckConstraint("CH_ReservationCar_EndTime", "EndTime > StartTime");
                    table.CheckConstraint("CH_ReservationCar_StartTime", "StartTime > SYSDATETIME()");
                    table.ForeignKey(
                        name: "FK_ReservationCars_CarRentals_CarRentalId",
                        column: x => x.CarRentalId,
                        principalTable: "CarRentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationCars_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservationWeddingHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    DayTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SweetType = table.Column<int>(type: "int", nullable: false),
                    BeverageType = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    WeddingHallId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(3448))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationWeddingHalls", x => x.Id);
                    table.CheckConstraint("CH_ReservationWeddingHall_BeverageType", "BeverageType BETWEEN 101 AND 102");
                    table.CheckConstraint("CH_ReservationWeddingHall_DayTime", "DayTime > SYSDATETIME()");
                    table.CheckConstraint("CH_ReservationWeddingHall_GuestCount", "GuestCount > 0");
                    table.CheckConstraint("CH_ReservationWeddingHall_SweetType", "SweetType BETWEEN 101 AND 104");
                    table.ForeignKey(
                        name: "FK_ReservationWeddingHalls_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservationWeddingHalls_WeddingHalls_WeddingHallId",
                        column: x => x.WeddingHallId,
                        principalTable: "WeddingHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatsNumber = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StartPrice = table.Column<float>(type: "real", nullable: false),
                    WeddingHallId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 25, 0, 7, 13, 267, DateTimeKind.Local).AddTicks(7054))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.CheckConstraint("CH_Room_RoomName", "LEN(RoomName) > 3");
                    table.CheckConstraint("Ch_Room_SeatsNumber", "LEN(SeatsNumber) > 0");
                    table.CheckConstraint("Ch_Room_StartPrice", "LEN(StartPrice) > 0");
                    table.ForeignKey(
                        name: "FK_Rooms_WeddingHalls_WeddingHallId",
                        column: x => x.WeddingHallId,
                        principalTable: "WeddingHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_AgentId",
                table: "CarRentals",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_LicensePlate",
                table: "CarRentals",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_UserId",
                table: "CarRentals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCars_CarRentalId",
                table: "ReservationCars",
                column: "CarRentalId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCars_ReservationId",
                table: "ReservationCars",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationWeddingHalls_ReservationId",
                table: "ReservationWeddingHalls",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationWeddingHalls_WeddingHallId",
                table: "ReservationWeddingHalls",
                column: "WeddingHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WeddingHallId",
                table: "Rooms",
                column: "WeddingHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalNo",
                table: "Users",
                column: "NationalNo",
                unique: true,
                filter: "UserType IN ('101','102','103')");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeddingHalls_AgentId",
                table: "WeddingHalls",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingHalls_UserId",
                table: "WeddingHalls",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationCars");

            migrationBuilder.DropTable(
                name: "ReservationWeddingHalls");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CarRentals");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "WeddingHalls");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
