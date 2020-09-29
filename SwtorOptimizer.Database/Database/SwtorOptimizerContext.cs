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
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Config"))
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
        public DbSet<Enhancement> Enhancements { get; set; }
        public DbSet<EnhancementSetEnhancement> EnhancementSetEnhancements { get; set; }
        public DbSet<EnhancementSet> EnhancementSets { get; set; }
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

            modelBuilder.Entity<Enhancement>(entity => entity.HasKey(e => e.Id));

            modelBuilder.Entity<EnhancementSet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.CalculationTask).WithMany(e => e.EnhancementSets);
            });

            modelBuilder.Entity<CalculationTask>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.EnhancementSets).WithOne(e => e.CalculationTask);
            });

            modelBuilder.Entity<EnhancementSetEnhancement>().HasKey(e => e.Id);

            modelBuilder.Entity<EnhancementSetEnhancement>()
                .HasOne(e => e.Enhancement)
                .WithMany(e => e.EnhancementSetEnhancements)
                .HasForeignKey(e => e.EnhancementId);

            modelBuilder.Entity<EnhancementSetEnhancement>()
                .HasOne(e => e.EnhancementSet)
                .WithMany(e => e.EnhancementSetEnhancements)
                .HasForeignKey(e => e.EnhancementSetId);
        }
    }
}