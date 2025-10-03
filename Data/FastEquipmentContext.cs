//using Microsoft.EntityFrameworkCore;
//using ToolsBorrow.Models;
using Microsoft.EntityFrameworkCore;
using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public class FastEquipmentContext : DbContext
    {
        public FastEquipmentContext(DbContextOptions<FastEquipmentContext> options) 
            : base(options) { }

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Equipment entity
            modelBuilder.Entity<Equipment>()
                .Property(e => e.Type)
                .IsRequired()
                .HasConversion<string>();

            modelBuilder.Entity<Equipment>()
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.IsAvailable)
                .IsRequired();

            // Configure Request entity
            modelBuilder.Entity<Request>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Request>()
                .Property(r => r.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Request>()
                .Property(r => r.Phone)
                .IsRequired()
                .HasMaxLength(12);

            modelBuilder.Entity<Request>()
                .Property(r => r.Role)
                .IsRequired()
                .HasConversion<string>();

            modelBuilder.Entity<Request>()
                .Property(r => r.DurationDays)
                .IsRequired();

            modelBuilder.Entity<Request>()
                .Property(r => r.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasDefaultValue(RequestStatus.Pending);

            modelBuilder.Entity<Request>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("datetime('now')");

            // Configure relationship
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Equipment)
                .WithMany()
                .HasForeignKey(r => r.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
