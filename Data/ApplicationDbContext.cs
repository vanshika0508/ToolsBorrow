

using Microsoft.EntityFrameworkCore;
using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<BorrowRequest> BorrowRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the relationship
            modelBuilder.Entity<BorrowRequest>()
                .HasOne(br => br.Equipment)
                .WithMany(e => e.BorrowRequests)
                .HasForeignKey(br => br.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed initial equipment data
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { EquipmentId = 1, Type = "Laptop", Description = "Dell Latitude 14-inch", Availability = true },
                new Equipment { EquipmentId = 2, Type = "Laptop", Description = "MacBook Pro 13-inch", Availability = false },
                new Equipment { EquipmentId = 3, Type = "Tablet", Description = "iPad Air", Availability = true },
                new Equipment { EquipmentId = 4, Type = "Phone", Description = "iPhone 13", Availability = false },
                new Equipment { EquipmentId = 5, Type = "Laptop", Description = "HP EliteBook", Availability = true },
                new Equipment { EquipmentId = 6, Type = "Tablet", Description = "Samsung Galaxy Tab", Availability = true },
                new Equipment { EquipmentId = 7, Type = "Another", Description = "Projector", Availability = true },
                new Equipment { EquipmentId = 8, Type = "Phone", Description = "Google Pixel", Availability = true }
            );
        }
    }
}