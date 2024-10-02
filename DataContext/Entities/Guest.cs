using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Guest
    {   
       public Guid GuestId { get; set; }
       public string GuestName { get; set; }
       public int GuestPhoneNumber { get; set; }
       public string GuestAddress { get; set; }
       public int GuestRoomNumber { get; set; }
       #region[Keys]
       public Guid ManagerId { get; set; }
       public Guid BillId { get; set; }
       #endregion
       #region[Navigation]
       public Bill Bill { get; set; }
       public Manager Manager { get; set; }
       #endregion

    }
    public class GuestEntityConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(g => g.GuestId);
            builder.HasOne(g => g.Bill)
                .WithOne(b => b.Guest)
                .HasForeignKey<Guest>(g => g.BillId);
            builder.HasOne(g => g.Manager)
                .WithMany(m => m.Guests)
                .HasForeignKey(g => g.ManagerId);
        }
    }
}
