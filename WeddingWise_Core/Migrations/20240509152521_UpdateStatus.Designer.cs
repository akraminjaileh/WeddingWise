﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingWise_Core.Context;

#nullable disable

namespace WeddingWise_Core.Migrations
{
    [DbContext(typeof(WeddingWiseDbContext))]
    [Migration("20240509152521_UpdateStatus")]
    partial class UpdateStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.AgentTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreationDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 9, 18, 25, 21, 545, DateTimeKind.Local).AddTicks(4588));

                    b.Property<float>("Fees")
                        .HasColumnType("real");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("ReservationCarId")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationWeddingHallId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(101);

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("ReservationCarId")
                        .IsUnique()
                        .HasFilter("[ReservationCarId] IS NOT NULL");

                    b.HasIndex("ReservationWeddingHallId")
                        .IsUnique()
                        .HasFilter("[ReservationWeddingHallId] IS NOT NULL");

                    b.ToTable("AgentTransactions", t =>
                        {
                            t.HasCheckConstraint("CH_AgentTransaction_Status", "Status = 101 OR Status = 106");

                            t.HasCheckConstraint("CH_AgentTransaction_TotalAmount", "TotalAmount >= 0");

                            t.HasCheckConstraint("CH_AgentTransaction_TransactionType", "TransactionType BETWEEN 101 AND 102");
                        });
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.CarRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreationDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 9, 18, 25, 21, 545, DateTimeKind.Local).AddTicks(8036));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Modal")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("PricePerHour")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(106);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("CarRentals", t =>
                        {
                            t.HasCheckConstraint("CH_CarRental_Brand", "LEN(Brand) >= 3");

                            t.HasCheckConstraint("CH_CarRental_City", "City BETWEEN 101 AND 104");

                            t.HasCheckConstraint("CH_CarRental_PricePerHour", "PricePerHour > 0");

                            t.HasCheckConstraint("CH_CarRental_Status", "Status BETWEEN 106 AND 107");

                            t.HasCheckConstraint("CH_CarRental_Title", "LEN(Title) >= 3");

                            t.HasCheckConstraint("Ch_CarRental_Year", "Year < SYSDATETIME()");
                        });
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 9, 18, 25, 21, 546, DateTimeKind.Local).AddTicks(7610));

                    b.Property<float>("DiscountAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<float>("NetPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int>("PaymentMethod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(101);

                    b.Property<string>("PromoCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(101);

                    b.Property<float>("TaxAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<float>("TotalPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations", t =>
                        {
                            t.HasCheckConstraint("CH_Reservation_NetPrice", "NetPrice >= 0");

                            t.HasCheckConstraint("CH_Reservation_PaymentMethod", "PaymentMethod BETWEEN 101 AND 103");

                            t.HasCheckConstraint("CH_Reservation_Status", "Status BETWEEN 101 AND 105");

                            t.HasCheckConstraint("CH_Reservation_TotalPrice", "TotalPrice >= 0");
                        });
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.ReservationCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarRentalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarRentalId");

                    b.HasIndex("ReservationId");

                    b.ToTable("ReservationCars", t =>
                        {
                            t.HasCheckConstraint("CH_ReservationCar_EndTime", "EndTime > StartTime");

                            t.HasCheckConstraint("CH_ReservationCar_StartTime", "StartTime > SYSDATETIME()");
                        });
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.ReservationWeddingHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BeverageType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SweetType")
                        .HasColumnType("int");

                    b.Property<int>("WeddingHallId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("RoomId");

                    b.HasIndex("WeddingHallId");

                    b.ToTable("ReservationWeddingHalls", t =>
                        {
                            t.HasCheckConstraint("CH_ReservationWeddingHall_BeverageType", "BeverageType BETWEEN 101 AND 102");

                            t.HasCheckConstraint("CH_ReservationWeddingHall_EndTime", "EndTime > StartTime");

                            t.HasCheckConstraint("CH_ReservationWeddingHall_GuestCount", "GuestCount > 0");

                            t.HasCheckConstraint("CH_ReservationWeddingHall_StartTime", "StartTime > SYSDATETIME()");

                            t.HasCheckConstraint("CH_ReservationWeddingHall_SweetType", "SweetType BETWEEN 101 AND 106");
                        });
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 9, 18, 25, 21, 547, DateTimeKind.Local).AddTicks(6284));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SeatsNumber")
                        .HasColumnType("int");

                    b.Property<float>("StartPrice")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(106);

                    b.Property<int>("WeddingHallId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeddingHallId");

                    b.ToTable("Rooms", t =>
                        {
                            t.HasCheckConstraint("CH_Room_RoomName", "LEN(RoomName) > 3");

                            t.HasCheckConstraint("CH_Room_Status", "Status BETWEEN 106 AND 107");

                            t.HasCheckConstraint("Ch_Room_SeatsNumber", "LEN(SeatsNumber) > 0");

                            t.HasCheckConstraint("Ch_Room_StartPrice", "LEN(StartPrice) > 0");
                        });
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 9, 18, 25, 21, 553, DateTimeKind.Local).AddTicks(3546));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NationalNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NationalNo")
                        .IsUnique()
                        .HasFilter("UserType IN ('101','102','103')");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Users", t =>
                        {
                            t.HasCheckConstraint("CH_User_Birthday", "DATEADD(YEAR, 16, Birthday) <= SYSDATETIME()");

                            t.HasCheckConstraint("CH_User_City", "City BETWEEN 101 AND 104");

                            t.HasCheckConstraint("CH_User_Email", "Email Like '%@gmail.com' Or Email Like '%@outlook.com' or Email Like '%@yahoo.com'");

                            t.HasCheckConstraint("CH_User_Name", "Name NOT LIKE '%[^a-zA-Z ]%' AND LEN(Name) > 5");

                            t.HasCheckConstraint("Ch_User_NationalNo", "LEN(NationalNo)=10");

                            t.HasCheckConstraint("Ch_User_Password", "LEN([Password]) > 4\r\n                                   AND PATINDEX('%[A-Z]%', [Password]) > 0\r\n                                   AND PATINDEX('%[a-z]%', [Password]) > 0\r\n                                   AND PATINDEX('%[0-9]%', [Password]) > 0\r\n                                   AND PATINDEX('%[^a-zA-Z0-9]%', [Password]) > 0");

                            t.HasCheckConstraint("Ch_User_phone", "LEN(Phone)=10 AND (Phone LIKE '079%' OR Phone LIKE '078%' OR Phone LIKE '077%')");
                        });
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.WeddingHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 9, 18, 25, 21, 553, DateTimeKind.Local).AddTicks(9071));

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Review")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("UserId");

                    b.ToTable("WeddingHalls", t =>
                        {
                            t.HasCheckConstraint("CH_WeddingHall_City", "City BETWEEN 101 AND 104");

                            t.HasCheckConstraint("CH_WeddingHall_Title", "LEN(Title) > 3");
                        });
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.AgentTransaction", b =>
                {
                    b.HasOne("WeddingWise_Core.Models.Entities.User", "Agent")
                        .WithMany("AgentTransactions")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeddingWise_Core.Models.Entities.ReservationCar", "ReservationCar")
                        .WithOne("AgentTransaction")
                        .HasForeignKey("WeddingWise_Core.Models.Entities.AgentTransaction", "ReservationCarId");

                    b.HasOne("WeddingWise_Core.Models.Entities.ReservationWeddingHall", "ReservationWeddingHall")
                        .WithOne("AgentTransaction")
                        .HasForeignKey("WeddingWise_Core.Models.Entities.AgentTransaction", "ReservationWeddingHallId");

                    b.Navigation("Agent");

                    b.Navigation("ReservationCar");

                    b.Navigation("ReservationWeddingHall");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.CarRental", b =>
                {
                    b.HasOne("WeddingWise_Core.Models.Entities.User", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeddingWise_Core.Models.Entities.User", "User")
                        .WithMany("CarRentals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.Reservation", b =>
                {
                    b.HasOne("WeddingWise_Core.Models.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.ReservationCar", b =>
                {
                    b.HasOne("WeddingWise_Core.Models.Entities.CarRental", "CarRental")
                        .WithMany("ReservationCars")
                        .HasForeignKey("CarRentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeddingWise_Core.Models.Entities.Reservation", "Reservation")
                        .WithMany("ReservationCars")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CarRental");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.ReservationWeddingHall", b =>
                {
                    b.HasOne("WeddingWise_Core.Models.Entities.Reservation", "Reservation")
                        .WithMany("ReservationWeddingHalls")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WeddingWise_Core.Models.Entities.Room", "Room")
                        .WithMany("ReservationWeddingHalls")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WeddingWise_Core.Models.Entities.WeddingHall", "WeddingHall")
                        .WithMany("ReservationWeddingHalls")
                        .HasForeignKey("WeddingHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Room");

                    b.Navigation("WeddingHall");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.Room", b =>
                {
                    b.HasOne("WeddingWise_Core.Models.Entities.WeddingHall", "WeddingHall")
                        .WithMany("Rooms")
                        .HasForeignKey("WeddingHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeddingHall");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.WeddingHall", b =>
                {
                    b.HasOne("WeddingWise_Core.Models.Entities.User", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeddingWise_Core.Models.Entities.User", "User")
                        .WithMany("WeddingHalls")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.CarRental", b =>
                {
                    b.Navigation("ReservationCars");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.Reservation", b =>
                {
                    b.Navigation("ReservationCars");

                    b.Navigation("ReservationWeddingHalls");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.ReservationCar", b =>
                {
                    b.Navigation("AgentTransaction")
                        .IsRequired();
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.ReservationWeddingHall", b =>
                {
                    b.Navigation("AgentTransaction")
                        .IsRequired();
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.Room", b =>
                {
                    b.Navigation("ReservationWeddingHalls");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.User", b =>
                {
                    b.Navigation("AgentTransactions");

                    b.Navigation("CarRentals");

                    b.Navigation("Reservations");

                    b.Navigation("WeddingHalls");
                });

            modelBuilder.Entity("WeddingWise_Core.Models.Entities.WeddingHall", b =>
                {
                    b.Navigation("ReservationWeddingHalls");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}