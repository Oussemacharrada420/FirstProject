using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Manager
    {
        public  Guid ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerVersion { get; set; }
        public string ManagerLocation { get; set; }
        #region[Keys]

        #endregion
        #region[Navigation]
        public ICollection<Inventory> Inventories {  get; set; }=  new List<Inventory>();
        public ICollection<Guest> Guests { get; set; }
        #endregion


    }
    public class ManagerEntityConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.ManagerId);
            builder.Property(m => m.ManagerName).IsRequired().HasMaxLength(50);
            builder.HasMany(m => m.Guests)
                .WithOne(g => g.Manager)
                .HasForeignKey(g => g.ManagerId);

            builder.HasMany(m => m.Inventories)
                .WithOne(i => i.Manager)
                .HasForeignKey(i => i.ManagerId);
        }
    }
}
