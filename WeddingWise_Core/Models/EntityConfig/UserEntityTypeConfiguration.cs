using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.EntityConfig
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Foreign key 
            builder.HasMany(z => z.WeddingHalls)
                .WithOne(z => z.User).OnDelete(DeleteBehavior.NoAction);
          
            builder.HasMany(z => z.CarRentals)
                .WithOne(z => z.User).OnDelete(DeleteBehavior.NoAction);


            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.NationalNo).IsRequired(false);

            //UNIQUE
            builder.HasIndex(x => x.Phone).IsUnique(true);
            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.NationalNo).IsUnique(true)
                .HasFilter("UserType IN ('101','102','103')");

            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_User_Name", "Name NOT LIKE '%[^a-zA-Z ]%' AND LEN(Name) > 5"));
            builder.ToTable(x =>
            x.HasCheckConstraint("Ch_User_phone", "LEN(Phone)=10 AND (Phone LIKE '079%' OR Phone LIKE '078%' OR Phone LIKE '077%')"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_User_Email", "Email Like '%@gmail.com' Or Email Like '%@outlook.com' or Email Like '%@yahoo.com'"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_User_City", "City BETWEEN 101 AND 104"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_User_Birthday", "DATEADD(YEAR, 16, Birthday) <= SYSDATETIME()"));
            builder.ToTable(x =>
            x.HasCheckConstraint("Ch_User_NationalNo", "LEN(NationalNo)=10"));

            //String Max Length
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Phone).HasMaxLength(10);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.NationalNo).HasMaxLength(100);
            builder.Property(x => x.Address).HasMaxLength(200);

        }
    }

}
