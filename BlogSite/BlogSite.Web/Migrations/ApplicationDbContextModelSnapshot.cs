﻿// <auto-generated />
using System;
using Blogsite.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogSite.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Airline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SeatsAvailable")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableRooms")
                        .HasColumnType("int");

                    b.Property<string>("HotelUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerNight")
                        .HasColumnType("float");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlternativeText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TourId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2ee07a6f-acb1-49e2-80d8-f628026f2ab7",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            Name = "Admin",
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAOjPiLV4t51KJPlc/agjj5vQb5Mx8kLqA1OiqMVtO89OLhYdC2qw+xWN6Qn4LDtoA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "658b034a-b1f7-4baf-9f1e-73cc4bad22cc",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1986899c-82eb-45fc-8d36-d3440dd5aad7",
                            Email = "user@gmail.com.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            Name = "sarwar",
                            NormalizedEmail = "user@gmail.com.com",
                            NormalizedUserName = "user@gmail.com.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEBbu6NNH7Ul3FDFRrmdco0SriUIvTWnGB1HXrvvj2q+PqCD2OcmbaTsJXvOZmUdFHg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dce42f7b-78fb-4be4-aa1b-43c04282520e",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com.com"
                        });
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                            ConcurrencyStamp = "638648715733588037",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                            ConcurrencyStamp = "638648715733588057",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                            RoleId = new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210")
                        },
                        new
                        {
                            UserId = new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                            RoleId = new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a")
                        });
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("BookingID")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingID")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CancellationTerm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxiMumPeople")
                        .HasColumnType("int");

                    b.Property<int>("MiniMumPeople")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpotsAvailable")
                        .HasColumnType("int");

                    b.Property<string>("TourName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TourUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Booking", b =>
                {
                    b.HasOne("Blogsite.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany("Bookings")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Images", b =>
                {
                    b.HasOne("Blogsite.Infrastructure.Entities.Hotel", "Hotel")
                        .WithMany("Images")
                        .HasForeignKey("HotelId");

                    b.HasOne("Blogsite.Infrastructure.Entities.Tour", "Tour")
                        .WithMany("Images")
                        .HasForeignKey("TourId");

                    b.Navigation("Hotel");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.RoleClaim", b =>
                {
                    b.HasOne("Blogsite.Infrastructure.Entities.Membership.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.UserClaim", b =>
                {
                    b.HasOne("Blogsite.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.UserLogin", b =>
                {
                    b.HasOne("Blogsite.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.UserRole", b =>
                {
                    b.HasOne("Blogsite.Infrastructure.Entities.Membership.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blogsite.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.UserToken", b =>
                {
                    b.HasOne("Blogsite.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Payment", b =>
                {
                    b.HasOne("Blogsite.Infrastructure.Entities.Booking", null)
                        .WithOne("Payment")
                        .HasForeignKey("Blogsite.Infrastructure.Entities.Payment", "BookingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Booking", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Hotel", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Membership.ApplicationUser", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Blogsite.Infrastructure.Entities.Tour", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
