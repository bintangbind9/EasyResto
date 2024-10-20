using EasyResto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EasyResto.Infrastructure.Context
{
    public class EasyRestoDbContext : DbContext
    {
        private readonly string _connectionString;

        public EasyRestoDbContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EasyResto"].ConnectionString;
        }

        public DbSet<FoodCategory> FoodCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("FoodCategory").HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);
            });
        }
    }
}
