using FitZone.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitZone.Infrastructure.Data
{
    public class FitZoneDbContext : DbContext
    {
        public FitZoneDbContext(DbContextOptions<FitZoneDbContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ADMIN;Database=FitZoneAppDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка иерархии Membership (TPH - Table-per-Hierarchy)
            modelBuilder.Entity<Membership>()
                .HasDiscriminator<string>("MembershipType")
                .HasValue<BasicMembership>("Basic")
                .HasValue<PremiumMembership>("Premium");

            // Настройка ограничений каскадного удаления во избежание конфликтов путей
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.WorkoutSession)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.SessionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}