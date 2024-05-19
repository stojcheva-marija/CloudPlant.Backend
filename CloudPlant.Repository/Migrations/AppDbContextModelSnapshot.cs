﻿// <auto-generated />
using System;
using CloudPlant.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CloudPlant.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CloudPlantUserId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CloudPlantUserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("HumidityMeasurement")
                        .HasColumnType("real");

                    b.Property<float>("LightIntensity")
                        .HasColumnType("real");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<float>("SoilMeasurement")
                        .HasColumnType("real");

                    b.Property<float>("TemperatureMeasurement")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastWatering")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlantTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("PlantTypeId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.PlantType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PlantTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ThresholdValue1")
                        .HasColumnType("real");

                    b.Property<float>("ThresholdValue2")
                        .HasColumnType("real");

                    b.Property<float>("ThresholdValue3")
                        .HasColumnType("real");

                    b.Property<float>("ThresholdValue4")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("PlantTypes");
                });

            modelBuilder.Entity("CloudPlant.Domain.Identity.CloudPlantUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CloudPlantUsers");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.Device", b =>
                {
                    b.HasOne("CloudPlant.Domain.Identity.CloudPlantUser", "User")
                        .WithMany("Devices")
                        .HasForeignKey("CloudPlantUserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.Measurement", b =>
                {
                    b.HasOne("CloudPlant.Domain.Domain_models.Plant", "Plant")
                        .WithMany("Measurements")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.Plant", b =>
                {
                    b.HasOne("CloudPlant.Domain.Domain_models.Device", "Device")
                        .WithMany("Plants")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloudPlant.Domain.Domain_models.PlantType", "PlantType")
                        .WithMany("Plants")
                        .HasForeignKey("PlantTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("PlantType");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.Device", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.Plant", b =>
                {
                    b.Navigation("Measurements");
                });

            modelBuilder.Entity("CloudPlant.Domain.Domain_models.PlantType", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("CloudPlant.Domain.Identity.CloudPlantUser", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
