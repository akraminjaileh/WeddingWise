using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.Models.EntityConfig
{
    public class ReservationCarEntityTypeConfiguration : IEntityTypeConfiguration<ReservationCar>
    {
        public void Configure(EntityTypeBuilder<ReservationCar> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsCompleted).HasDefaultValue(false);
          

            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_ReservationCar_StartTime", "StartTime > SYSDATETIME()"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_ReservationCar_EndTime", "EndTime > StartTime"));
            builder.ToTable(x =>
           x.HasCheckConstraint("CH_ReservationCar_StartTime", "StartTime > SYSDATETIME()"));
          

        }
    }

}
