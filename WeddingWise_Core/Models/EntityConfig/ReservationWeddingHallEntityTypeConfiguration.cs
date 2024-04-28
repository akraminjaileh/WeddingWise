using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.Models.EntityConfig
{
    public class ReservationWeddingHallEntityTypeConfiguration : IEntityTypeConfiguration<ReservationWeddingHall>
    {
        public void Configure(EntityTypeBuilder<ReservationWeddingHall> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTime.Now);

            //Check Constraint 
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_ReservationWeddingHall_GuestCount", "GuestCount > 0"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_ReservationWeddingHall_SweetType", "SweetType BETWEEN 101 AND 104"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_ReservationWeddingHall_BeverageType", "BeverageType BETWEEN 101 AND 102"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_ReservationWeddingHall_DayTime", "DayTime > SYSDATETIME()"));
           
        }
    }

}
