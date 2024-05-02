using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.EntityConfig
{
    public class RoomEntityTypeConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Foreign key 
            builder.HasMany(z => z.ReservationWeddingHalls)
                .WithOne(z => z.Room).OnDelete(DeleteBehavior.NoAction);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).HasDefaultValue(Status.Available);
            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.Description).IsRequired(false);


            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Room_RoomName", "LEN(RoomName) > 3"));
            builder.ToTable(x =>
            x.HasCheckConstraint("Ch_Room_SeatsNumber", "LEN(SeatsNumber) > 0"));
            builder.ToTable(x =>
            x.HasCheckConstraint("Ch_Room_StartPrice", "LEN(StartPrice) > 0"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Room_Status", "Status BETWEEN 106 AND 107"));

            //String Max Length
            builder.Property(x => x.Floor).HasMaxLength(20);
            builder.Property(x => x.RoomName).HasMaxLength(20);
            builder.Property(x => x.Description).HasMaxLength(200);


        }
    }

}
