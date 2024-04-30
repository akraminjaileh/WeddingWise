using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.EntityConfig
{
    public class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            //Foreign key 
            builder.HasMany(z => z.ReservationCars)
                .WithOne(z => z.Reservation).OnDelete(DeleteBehavior.NoAction);
             
            builder.HasMany(z => z.ReservationWeddingHalls)
              .WithOne(z => z.Reservation).OnDelete(DeleteBehavior.NoAction);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.TaxAmount).HasDefaultValue(0);
            builder.Property(x => x.DiscountAmount).HasDefaultValue(0);
            builder.Property(x => x.TotalPrice).HasDefaultValue(0);
            builder.Property(x => x.NetPrice).HasDefaultValue(0);
            builder.Property(x => x.Status).HasDefaultValue(Status.Pending);
            builder.Property(x => x.PaymentMethod).HasDefaultValue(PaymentMethod.Visa);
            builder.Property(x => x.PromoCode).IsRequired(false);
            


            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Reservation_Status", "Status BETWEEN 101 AND 105"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Reservation_PaymentMethod", "PaymentMethod BETWEEN 101 AND 103"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Reservation_NetPrice", "NetPrice >= 0"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Reservation_TotalPrice", "TotalPrice >= NetPrice"));

            //String Max Length
            builder.Property(x => x.PromoCode).HasMaxLength(20);

        }

    }
}
