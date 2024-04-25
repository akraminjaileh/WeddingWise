using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.EntityConfig
{
    public class WeddingHallEntityTypeConfiguration : IEntityTypeConfiguration<WeddingHall>
    {
        public void Configure(EntityTypeBuilder<WeddingHall> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.City).HasDefaultValue(City.Amman);
            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.Review).IsRequired(false);


            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_WeddingHall_Title", "LEN(Title) > 3"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_WeddingHall_City", "City BETWEEN 101 AND 104"));

            //String Max Length
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Review).HasMaxLength(200);

            //Foreign key 
            builder.HasOne(z => z.User)
                .WithMany(z => z.WeddingHalls).OnDelete(DeleteBehavior.NoAction);

        }
    }

}
