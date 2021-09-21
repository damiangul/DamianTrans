using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class DamianTransDbContext : DbContext
    {
        private string _connectionString = "Server=.;Database=DamianTrans;Trusted_Connection=True;";

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ThingToDeliver> ThingsToDeliver { get; set; }
        public DbSet<Worker> Workers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    modelbuilder.Entity<Delivery>()
        //        .HasOne(p => p.Car)
        //        .WithMany(p => p.Deliveries)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    modelbuilder.Entity<Delivery>()
        //        .HasOne(p => p.Worker)
        //        .WithMany(p => p.Deliveries)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    modelbuilder.Entity<Delivery>()
        //        .HasOne(p => p.Client)
        //        .WithMany(p => p.Deliveries)
        //        .OnDelete(DeleteBehavior.SetNull);

        //    //var changeToSetNullWhenDelete = modelbuilder.Entity<Delivery>();

        //    //foreach (var element in changeToSetNullWhenDelete)
        //    //{
        //    //    element.DeleteBehavior = DeleteBehavior.SetNull;
        //    //}

        //    //foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //    //{
        //    //    relationship.DeleteBehavior = DeleteBehavior.SetNull;
        //    //}

        //    //base.OnModelCreating(modelbuilder);
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
