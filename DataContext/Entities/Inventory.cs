using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Entities
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public string InventoryType { get; set; }
        public string InventoryStatus { get; set; }

        #region[Keys]
        public Guid ManagerId { get; set; }
        #endregion   
        #region[Navigation]
        public Manager Manager { get; set; }
        #endregion
    }
    public class InventoryEntityConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.InventoryId);
            builder.Property(i => i.InventoryType).IsRequired().HasMaxLength(50);
            builder.Property(i => i.InventoryStatus).IsRequired().HasMaxLength(50);

            builder.HasOne(i => i.Manager)
                .WithMany(m => m.Inventories)
                .HasForeignKey(i => i.ManagerId);
        }
    }
}
