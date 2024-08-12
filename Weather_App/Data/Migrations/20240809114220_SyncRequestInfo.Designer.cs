﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather_App.Data;

#nullable disable

namespace Weather_App.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240809114220_SyncRequestInfo")]
    partial class SyncRequestInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Weather_App.Models.Entities.Astro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("IsMoonUp")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSunUp")
                        .HasColumnType("bit");

                    b.Property<float?>("MoonIllumination")
                        .HasColumnType("real");

                    b.Property<string>("MoonPhase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moonrise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moonset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sunrise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sunset")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Astro");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.Condition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int?>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.Current", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<float?>("Cloud")
                        .HasColumnType("real");

                    b.Property<long>("ConditionId")
                        .HasColumnType("bigint");

                    b.Property<float?>("DewpointCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("DewpointFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("FeelsLikeTemperatureCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("FeelsLikeTemperatureFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("GustKPH")
                        .HasColumnType("real");

                    b.Property<float?>("GustMPH")
                        .HasColumnType("real");

                    b.Property<float?>("HeatIndexCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("HeatIndexFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("Humidity")
                        .HasColumnType("real");

                    b.Property<bool>("IsDay")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastUpdatedEpoch")
                        .HasColumnType("bigint");

                    b.Property<float?>("PrecipInches")
                        .HasColumnType("real");

                    b.Property<float?>("PrecipMillimetres")
                        .HasColumnType("real");

                    b.Property<float?>("PressureHgInches")
                        .HasColumnType("real");

                    b.Property<float?>("PressureMilibars")
                        .HasColumnType("real");

                    b.Property<float?>("TemperatureCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("TemperatureFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("UVIndex")
                        .HasColumnType("real");

                    b.Property<float?>("VisibilityKilometers")
                        .HasColumnType("real");

                    b.Property<float?>("VisibilityMiles")
                        .HasColumnType("real");

                    b.Property<float?>("WindChillCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("WindChillFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("WindDegree")
                        .HasColumnType("real");

                    b.Property<string>("WindDirection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("WindKPH")
                        .HasColumnType("real");

                    b.Property<float?>("WindMPH")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId")
                        .IsUnique();

                    b.ToTable("Current");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.ForecastDay", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("AstroId")
                        .HasColumnType("bigint");

                    b.Property<int?>("AvgHumidity")
                        .HasColumnType("int");

                    b.Property<float?>("AvgTemperatureCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("AvgTemperatureFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("AvgVisibilityKilometers")
                        .HasColumnType("real");

                    b.Property<float?>("AvgVisibilityMiles")
                        .HasColumnType("real");

                    b.Property<int?>("ChanceOfRain")
                        .HasColumnType("int");

                    b.Property<int?>("ChanceOfSnow")
                        .HasColumnType("int");

                    b.Property<long>("ConditionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DateEpoch")
                        .HasColumnType("bigint");

                    b.Property<float?>("MaxTemperatureCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("MaxTemperatureFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("MaxWindKPH")
                        .HasColumnType("real");

                    b.Property<float?>("MaxWindMPH")
                        .HasColumnType("real");

                    b.Property<float?>("MinTemperatureCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("MinTemperatureFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("TotalPrecipInches")
                        .HasColumnType("real");

                    b.Property<float?>("TotalPrecipMillimetres")
                        .HasColumnType("real");

                    b.Property<float?>("TotalSnowCentimeters")
                        .HasColumnType("real");

                    b.Property<float?>("UVIndex")
                        .HasColumnType("real");

                    b.Property<long>("WeatherForecastId")
                        .HasColumnType("bigint");

                    b.Property<bool>("WillItRain")
                        .HasColumnType("bit");

                    b.Property<bool>("WillItSnow")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AstroId");

                    b.HasIndex("ConditionId");

                    b.HasIndex("WeatherForecastId");

                    b.ToTable("ForecastDay");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.ForecastHour", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int?>("ChanceOfRain")
                        .HasColumnType("int");

                    b.Property<int?>("ChanceOfSnow")
                        .HasColumnType("int");

                    b.Property<float?>("Cloud")
                        .HasColumnType("real");

                    b.Property<long>("ConditionId")
                        .HasColumnType("bigint");

                    b.Property<float?>("DewpointCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("DewpointFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("FeelsLikeTemperatureCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("FeelsLikeTemperatureFahrenheit")
                        .HasColumnType("real");

                    b.Property<long>("ForecastDayId")
                        .HasColumnType("bigint");

                    b.Property<float?>("GustKPH")
                        .HasColumnType("real");

                    b.Property<float?>("GustMPH")
                        .HasColumnType("real");

                    b.Property<float?>("HeatIndexCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("HeatIndexFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("Humidity")
                        .HasColumnType("real");

                    b.Property<bool>("IsDay")
                        .HasColumnType("bit");

                    b.Property<float?>("PrecipInches")
                        .HasColumnType("real");

                    b.Property<float?>("PrecipMillimetres")
                        .HasColumnType("real");

                    b.Property<float?>("PressureHgInches")
                        .HasColumnType("real");

                    b.Property<float?>("PressureMilibars")
                        .HasColumnType("real");

                    b.Property<float?>("SnowCentimeters")
                        .HasColumnType("real");

                    b.Property<float?>("TemperatureCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("TemperatureFahrenheit")
                        .HasColumnType("real");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.Property<long?>("TimeEpoch")
                        .HasColumnType("bigint");

                    b.Property<float?>("UVIndex")
                        .HasColumnType("real");

                    b.Property<float?>("VisibilityKilometers")
                        .HasColumnType("real");

                    b.Property<float?>("VisibilityMiles")
                        .HasColumnType("real");

                    b.Property<bool>("WillItRain")
                        .HasColumnType("bit");

                    b.Property<bool>("WillItSnow")
                        .HasColumnType("bit");

                    b.Property<float?>("WindChillCelsius")
                        .HasColumnType("real");

                    b.Property<float?>("WindChillFahrenheit")
                        .HasColumnType("real");

                    b.Property<float?>("WindDegree")
                        .HasColumnType("real");

                    b.Property<string>("WindDirection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("WindKPH")
                        .HasColumnType("real");

                    b.Property<float?>("WindMPH")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("ForecastDayId");

                    b.ToTable("ForecastHour");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real");

                    b.Property<DateTime?>("Localtime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LocaltimeEpoch")
                        .HasColumnType("bigint");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeZone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.Management.SyncRequestInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AdditionalEntities")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("AdditionalInformations")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("ApiName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BaseAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BaseEntity")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("EndPoint")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("ExecutionTime")
                        .HasColumnType("bigint");

                    b.Property<int>("GlobalCount")
                        .HasColumnType("int");

                    b.Property<string>("Parameters")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ProcessingDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reconnections")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SyncRequestInfo");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.WeatherCurrent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("CurrentId")
                        .HasColumnType("bigint");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.HasIndex("CurrentId")
                        .IsUnique();

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("WeatherCurrent");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.WeatherForecast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("CurrentId")
                        .HasColumnType("bigint");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.HasIndex("CurrentId")
                        .IsUnique();

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("WeatherForecast");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Weather_App.Models.Entities.Current", b =>
                {
                    b.HasOne("Weather_App.Models.Entities.Condition", "Condition")
                        .WithOne()
                        .HasForeignKey("Weather_App.Models.Entities.Current", "ConditionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Condition");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.ForecastDay", b =>
                {
                    b.HasOne("Weather_App.Models.Entities.Astro", "Astro")
                        .WithMany()
                        .HasForeignKey("AstroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weather_App.Models.Entities.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weather_App.Models.Entities.WeatherForecast", "WeatherForecast")
                        .WithMany("ForecastDays")
                        .HasForeignKey("WeatherForecastId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Astro");

                    b.Navigation("Condition");

                    b.Navigation("WeatherForecast");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.ForecastHour", b =>
                {
                    b.HasOne("Weather_App.Models.Entities.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weather_App.Models.Entities.ForecastDay", "ForecastDay")
                        .WithMany("ForecastHours")
                        .HasForeignKey("ForecastDayId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("ForecastDay");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.WeatherCurrent", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Account")
                        .WithOne()
                        .HasForeignKey("Weather_App.Models.Entities.WeatherCurrent", "AccountId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Weather_App.Models.Entities.Current", "Current")
                        .WithOne()
                        .HasForeignKey("Weather_App.Models.Entities.WeatherCurrent", "CurrentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Weather_App.Models.Entities.Location", "Location")
                        .WithOne()
                        .HasForeignKey("Weather_App.Models.Entities.WeatherCurrent", "LocationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Current");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.WeatherForecast", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Account")
                        .WithOne()
                        .HasForeignKey("Weather_App.Models.Entities.WeatherForecast", "AccountId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Weather_App.Models.Entities.Current", "Current")
                        .WithOne()
                        .HasForeignKey("Weather_App.Models.Entities.WeatherForecast", "CurrentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Weather_App.Models.Entities.Location", "Location")
                        .WithOne()
                        .HasForeignKey("Weather_App.Models.Entities.WeatherForecast", "LocationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Current");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.ForecastDay", b =>
                {
                    b.Navigation("ForecastHours");
                });

            modelBuilder.Entity("Weather_App.Models.Entities.WeatherForecast", b =>
                {
                    b.Navigation("ForecastDays");
                });
#pragma warning restore 612, 618
        }
    }
}
