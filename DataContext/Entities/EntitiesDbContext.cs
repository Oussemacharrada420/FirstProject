using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class EntitiesDbContext : DbContext
    {
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Chef> Chef { get; set; }
        public DbSet<FoodItems> FoodItems { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<HouseKeeping> HouseKeeping { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Receptionist> ReceptionistManager { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
                    b => b.MigrationsAssembly("WebApplication2")); // Specify the project name here
            }
        }

        public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BillEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ChefEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FoodItemsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GuestEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HouseKeepingEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReceptionistEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoomsEntityConfiguration());
        }
    } 
}
