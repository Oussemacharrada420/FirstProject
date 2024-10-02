using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class HouseKeeping
    {
        public Guid HouseKeepingId { get; set; }
        public string HouseKeepingName { get; set; } = string.Empty;
        public string HouseKeepingLocation { get; set; } = string.Empty;


    }
    public class HouseKeepingEntityConfiguration : IEntityTypeConfiguration<HouseKeeping>
    {
        public void Configure(EntityTypeBuilder<HouseKeeping> builder)
        {

        }
    }
}
