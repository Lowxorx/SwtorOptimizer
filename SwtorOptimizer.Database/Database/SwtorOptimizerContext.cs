using System;
using Microsoft.EntityFrameworkCore;
using SwtorOptimizer.Business.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SwtorOptimizer.Database.Database
{
    public class SwtorOptimizerContext : DbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public SwtorOptimizerContext()
        // C# will call base class parameterless constructor by default
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config"))
                .AddJsonFile("appsettings.json", false, true);

            this.configuration = config.Build();

            this.connectionString = this.configuration.GetSection("AppSettings:ConnectionString").Value;
        }

        public SwtorOptimizerContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SwtorOptimizerContext(DbContextOptions<SwtorOptimizerContext> options) : base(options)
        {
        }

        public DbSet<CalculationTask> CalculationTasks { get; set; }
        public DbSet<GearPiece> GearPieces { get; set; }
        public DbSet<GearPieceSetGearPiece> GearPieceSetGearPieces { get; set; }
        public DbSet<GearPieceSet> GearPieceSets { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => entity.HasKey(e => e.Id));

            modelBuilder.Entity<Package>(entity => entity.HasKey(e => e.Id));

            modelBuilder.Entity<GearPiece>(entity => entity.HasKey(e => e.Id));

            modelBuilder.Entity<GearPieceSet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.CalculationTask).WithMany(e => e.GearPieceSets);
            });

            modelBuilder.Entity<CalculationTask>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.GearPieceSets).WithOne(e => e.CalculationTask);
            });

            modelBuilder.Entity<GearPieceSetGearPiece>().HasKey(e => e.Id);

            modelBuilder.Entity<GearPieceSetGearPiece>()
                .HasOne(e => e.GearPiece)
                .WithMany(e => e.GearPieceSetGearPieces)
                .HasForeignKey(e => e.GearPieceId);

            modelBuilder.Entity<GearPieceSetGearPiece>()
                .HasOne(e => e.GearPieceSet)
                .WithMany(e => e.GearPieceSetGearPieces)
                .HasForeignKey(e => e.GearPieceSetId);
        }
    }
}