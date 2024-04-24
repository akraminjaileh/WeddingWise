using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.EntityConfig
{
    public class CarRentalEntityTypeConfiguration : IEntityTypeConfiguration<CarRental>
    {
        public void Configure(EntityTypeBuilder<CarRental> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.City).HasDefaultValue(City.Amman);
            builder.Property(x => x.Description).IsRequired(false);

            //UNIQUE
            builder.HasIndex(x => x.LicensePlate).IsUnique(true);

            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_CarRental_Title", "LEN(Title) > 3"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_CarRental_Brand", "LEN(Brand) > 3"));
            builder.ToTable(x =>
            x.HasCheckConstraint("Ch_CarRental_Year", "Year < SYSDATETIME()"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_CarRental_City", "City BETWEEN 101 AND 104"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_CarRental_PricePerHour", "PricePerHour > 0"));

            //String Max Length
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Color).HasMaxLength(20);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.LicensePlate).HasMaxLength(20);
            builder.Property(x => x.Brand).HasMaxLength(20);
            builder.Property(x => x.Modal).HasMaxLength(20);
            builder.Property(x => x.Address).HasMaxLength(200);

        }

    }

}
