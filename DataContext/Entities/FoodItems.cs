using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class FoodItems
    {
        public Guid FoodItemsId { get; set; }
        public string FoodItemsName { get; set; } = string.Empty;
        #region[Keys]

        #endregion
        #region[Navigtion]
        public ICollection<Chef> Chefs { get; set; }

        #endregion
    }
    public class FoodItemsEntityConfiguration : IEntityTypeConfiguration<FoodItems>
    {
        public void Configure(EntityTypeBuilder<FoodItems> builder)
        {
            builder.HasKey(fi => fi.FoodItemsId);

            builder.Property(fi => fi.FoodItemsName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(fi => fi.Chefs)
                .WithMany(c => c.FoodItems);

        }
    }
}
