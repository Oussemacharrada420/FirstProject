using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Receptionist
    {
        public Guid ReceptionistId { get; set; }
        public string ReceptionistName { get; set; } = string.Empty;
        public string ReceptionistLocation { get; set; } = string.Empty;
        public int ReceptionistPhoneNumber { get; set; }
        #region[Keys]
        public Guid BillId { get; set; }
        #endregion

        #region[Navigation]
        public Bill Bill { get; set; }
        #endregion
    }

    public class ReceptionistEntityConfiguration : IEntityTypeConfiguration<Receptionist>
    {
        public void Configure(EntityTypeBuilder<Receptionist> builder)
        {
            builder.HasKey(r => r.ReceptionistId);
            builder.Property(r => r.ReceptionistName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(r => r.ReceptionistLocation)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(r => r.ReceptionistPhoneNumber)
                .IsRequired();

            builder.HasOne(r => r.Bill)
                .WithMany(b => b.Receptionists)
                .HasForeignKey(r => r.BillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
