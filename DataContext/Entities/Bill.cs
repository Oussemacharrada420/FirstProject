using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Bill
    {
        public Guid BillId { get; set; }
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "The phone number is not valid.")]
        public int BillNumber { get; set; }
        #region[Keys]
        public Guid GuestId { get; set; }
        #endregion
        #region[Navigation]
        public Guest Guest { get; set; }
        public ICollection<Receptionist> Receptionists { get; set; } = new List<Receptionist>();

        #endregion

    }
    public class BillEntityConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(b => b.BillId);
            builder.Property(b => b.BillNumber)
                .IsRequired()
                .HasMaxLength(15);


            #region[ForeignKeys]
            builder.HasOne(b => b.Guest)
                .WithOne(g => g.Bill)
                .HasForeignKey<Guest>(g => g.BillId);
            builder.HasMany(  b => b.Receptionists)
                .WithOne(r => r.Bill)
                .HasForeignKey(r => r.BillId) 
                .OnDelete(DeleteBehavior.Restrict); ;
            #endregion

        }
    }
}
