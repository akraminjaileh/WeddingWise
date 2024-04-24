using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.EntityConfig
{
    public class AgentTransactionEntityTypeConfiguration : IEntityTypeConfiguration<AgentTransaction>
    {
        public void Configure(EntityTypeBuilder<AgentTransaction> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Nullable(is Not Null By Default) ** Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).HasDefaultValue(Status.Pending);



            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_AgentTransaction_Balance", "Balance >= 0"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_AgentTransaction_Fees", "Fees >= 0"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_AgentTransaction_Status", "Status = 101 OR Status = 102"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_AgentTransaction_TransactionType", "TransactionType BETWEEN 101 AND 102"));

        }
    }

}
