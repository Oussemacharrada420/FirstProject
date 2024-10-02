using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Chef
    {
        public Guid ChefId { get; set; }
        public string ChefName { get; set; } = string.Empty;
        public string ChefLocation { get; set; } = string.Empty;
        #region[Keys]

        #endregion
        #region[Navigtion]
        public ICollection<FoodItems> FoodItems { get; set; }

        #endregion

    }
    public class ChefEntityConfiguration : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            #region[properties]
            builder.HasKey(c => c.ChefId);
            builder.Property(c => c.ChefName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.ChefLocation).IsRequired().HasMaxLength(100);
            #endregion
            #region[Foreign keys]
            builder.HasMany<FoodItems>(c => c.FoodItems)
                .WithMany(C => C.Chefs);
            
            #endregion




        }
    }
}
