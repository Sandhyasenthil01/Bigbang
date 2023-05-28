﻿// <auto-generated />
using System;
using BIGBANG_ASSESSMENT.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BIGBANG_ASSESSMENT.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20230528124252_mi")]
    partial class mi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BIGBANG_ASSESSMENT.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BIGBANG_ASSESSMENT.Models.Hotels", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<string>("Amenities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RoomAvailability")
                        .HasColumnType("int");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("BIGBANG_ASSESSMENT.Models.Rooms", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int?>("HotelsHotelId")
                        .HasColumnType("int");

                    b.Property<string>("Room_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelsHotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BIGBANG_ASSESSMENT.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<int?>("HotelsHotelId")
                        .HasColumnType("int");

                    b.Property<string>("StaffName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffId");

                    b.HasIndex("HotelsHotelId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ClassLibrary3.Models.Booking", b =>
                {
                    b.Property<int>("Booking_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Booking_id"));

                    b.Property<DateTime>("Check_in_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Check_out_date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomersCustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("hotelsHotelId")
                        .HasColumnType("int");

                    b.HasKey("Booking_id");

                    b.HasIndex("CustomersCustomerId");

                    b.HasIndex("hotelsHotelId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BIGBANG_ASSESSMENT.Models.Rooms", b =>
                {
                    b.HasOne("BIGBANG_ASSESSMENT.Models.Hotels", "Hotels")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelsHotelId");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("BIGBANG_ASSESSMENT.Models.Staff", b =>
                {
                    b.HasOne("BIGBANG_ASSESSMENT.Models.Hotels", "Hotels")
                        .WithMany("Staff")
                        .HasForeignKey("HotelsHotelId");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("ClassLibrary3.Models.Booking", b =>
                {
                    b.HasOne("BIGBANG_ASSESSMENT.Models.Customer", "Customers")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomersCustomerId");

                    b.HasOne("BIGBANG_ASSESSMENT.Models.Hotels", "hotels")
                        .WithMany("Bookings")
                        .HasForeignKey("hotelsHotelId");

                    b.Navigation("Customers");

                    b.Navigation("hotels");
                });

            modelBuilder.Entity("BIGBANG_ASSESSMENT.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BIGBANG_ASSESSMENT.Models.Hotels", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Rooms");

                    b.Navigation("Staff");
                });
#pragma warning restore 612, 618
        }
    }
}
