﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Migrations
{
    [DbContext(typeof(SwtorOptimizerContext))]
    [Migration("20201210130458_GearType")]
    partial class GearType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.CalculationTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoundSets")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Threshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CalculationTasks");
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.GearPiece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Endurance")
                        .HasColumnType("int");

                    b.Property<int>("GearPieceType")
                        .HasColumnType("int");

                    b.Property<int>("Mastery")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("Tertiary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GearPieces");
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.GearSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalculationTaskId")
                        .HasColumnType("int");

                    b.Property<bool>("IsInvalid")
                        .HasColumnType("bit");

                    b.Property<string>("SetInternalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Threshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalculationTaskId");

                    b.ToTable("GearSets");
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.GearSetGearPiece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GearPieceId")
                        .HasColumnType("int");

                    b.Property<int>("GearSetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GearPieceId");

                    b.HasIndex("GearSetId");

                    b.ToTable("GearSetGearPieces");
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.GearSet", b =>
                {
                    b.HasOne("SwtorOptimizer.Business.Entities.CalculationTask", "CalculationTask")
                        .WithMany("EnhancementSets")
                        .HasForeignKey("CalculationTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.GearSetGearPiece", b =>
                {
                    b.HasOne("SwtorOptimizer.Business.Entities.GearPiece", "GearPiece")
                        .WithMany("GearSetEnhancements")
                        .HasForeignKey("GearPieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwtorOptimizer.Business.Entities.GearSet", "GearSet")
                        .WithMany("GearSetGearPieces")
                        .HasForeignKey("GearSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
