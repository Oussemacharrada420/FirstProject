using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Rooms
    {
        public Guid RoomId { get; set; }
        public string RoomLocation   { get; set; }  
        public int RoomNumber { get; set; }

    }
    public class RoomsEntityConfiguration : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {
            builder.HasKey(r => r.RoomId);
            builder.Property(r => r.RoomLocation).IsRequired();
            builder.Property(r => r.RoomNumber).IsRequired();
        }
    }
}
