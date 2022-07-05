using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;
using System;
using System.Linq;

namespace OrderSystem
{
    public class OrderSystemDbContext:DbContext
    {
        public OrderSystemDbContext(DbContextOptions<OrderSystemDbContext> options)
        : base(options)
        {
        }
        public virtual DbSet<EveEvent> EveEvents { get; set; } = null!;
        public DbSet<ProOrd> ProOrds { get; set; } = null!;
        public virtual DbSet<OrdOrder> OrdOrders { get; set; } = null!;
        public virtual DbSet<ProProduct> ProProducts { get; set; } = null!;
        public virtual DbSet<ShiShift> ShiShifts { get; set; } = null!;
        public virtual DbSet<StaStation> StaStations { get; set; } = null!;
        public virtual DbSet<PerPerson> PerPersons { get; set; } = null!;
        public virtual DbSet<UsrUser> UsrUsers { get; set; } = null!;
        public virtual DbSet<RoRole> RoRoles { get; set; } = null!;
        public virtual DbSet<OStOrderStatus> OStOrderStatuses { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsrUser>()
                .HasOne(u => u.PerPerson)
                .WithOne(p => p.UsrUser)
                .HasForeignKey<PerPerson>(p => p.UsrUserId);
            modelBuilder.Entity<ProOrd>()
                .HasKey(po => new { po.ProId, po.OrdId });
            modelBuilder.Entity<ProOrd>()
                .HasOne(po => po.Order)
                .WithMany(po => po.ProProducts)
                .HasForeignKey(po => po.OrdId);
            modelBuilder.Entity<ProOrd>()
                .HasOne(po => po.Product)
                .WithMany(po => po.OrdOrders)
                .HasForeignKey(po => po.ProId);

        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is OrdOrder && (
                        e.State == EntityState.Added));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((OrdOrder)entityEntry.Entity).OrdTimeStamp = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
