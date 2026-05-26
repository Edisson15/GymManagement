using GymManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GymManagement.DataAccess.Context
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members => Set<Member>();
        public DbSet<Trainer> Trainers => Set<Trainer>();
        public DbSet<GymClass> GymClasses => Set<GymClass>();
        public DbSet<Membership> Memberships => Set<Membership>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Membership>()
                .Property(m => m.Price)
                .HasColumnType("decimal(10,2)");

            //  Relación N:M → Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Member)
                .WithMany(m => m.Enrollments)
                .HasForeignKey(e => e.MemberId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.GymClass)
                .WithMany(gc => gc.Enrollments)
                .HasForeignKey(e => e.GymClassId);

            //  Member → Membership (N:1)
            modelBuilder.Entity<Member>()
                .HasOne(m => m.Membership)
                .WithMany(ms => ms.Members)
                .HasForeignKey(m => m.MembershipId);

            //  Trainer → GymClass (1:N)
            modelBuilder.Entity<GymClass>()
                .HasOne(gc => gc.Trainer)
                .WithMany(t => t.GymClasses)
                .HasForeignKey(gc => gc.TrainerId);
        }
    }
}