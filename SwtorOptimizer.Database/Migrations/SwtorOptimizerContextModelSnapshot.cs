﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Migrations
{
    [DbContext(typeof(SwtorOptimizerContext))]
    partial class SwtorOptimizerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.Enhancement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccuracyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlacrityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CriticalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Endurance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("Tertiary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enhancements");
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.EnhancementSet", b =>
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

                    b.ToTable("EnhancementSets");
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.EnhancementSetEnhancement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnhancementId")
                        .HasColumnType("int");

                    b.Property<int>("EnhancementSetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnhancementId");

                    b.HasIndex("EnhancementSetId");

                    b.ToTable("EnhancementSetEnhancements");
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Endurance")
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

                    b.ToTable("Packages");
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

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.EnhancementSet", b =>
                {
                    b.HasOne("SwtorOptimizer.Business.Entities.CalculationTask", "CalculationTask")
                        .WithMany("EnhancementSets")
                        .HasForeignKey("CalculationTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwtorOptimizer.Business.Entities.EnhancementSetEnhancement", b =>
                {
                    b.HasOne("SwtorOptimizer.Business.Entities.Enhancement", "Enhancement")
                        .WithMany("EnhancementSetEnhancements")
                        .HasForeignKey("EnhancementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwtorOptimizer.Business.Entities.EnhancementSet", "EnhancementSet")
                        .WithMany("EnhancementSetEnhancements")
                        .HasForeignKey("EnhancementSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
